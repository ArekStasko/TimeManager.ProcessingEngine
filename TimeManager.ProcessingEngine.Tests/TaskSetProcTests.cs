using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using TimeManager.ProcessingEngine.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TimeManager.ProcessingEngine.Processors;
using TimeManager.ProcessingEngine.Tests.Data;
using Newtonsoft.Json;

namespace TimeManager.ProcessingEngine.Tests
{
    [TestClass]
    public class TaskSetProcTests
    {
        private Mock<DbSet<TaskSetRecord>> GetMockDbSet()
        {
            var data = new List<TaskSetRecord>
            {
               new TaskSetRecord
               {
                   Id = 1,
                   UserId = 1,
                   TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=1,
                           Date = DateTime.Now,
                       }
                   },
                   Task = new TaskDTO
                    {
                     Id = 1,
                     Name = "TestName",
                     Description  = "TestDescription",
                     Type = "TestType",
                     DateAdded = DateTime.Now,
                     DateCompleted = DateTime.Now,
                     Deadline = DateTime.Now,
                     Priority = 4,
                     UserId = 1
                    }
               },
               new TaskSetRecord
               {
                   Id = 2,
                   UserId = 2,
                   TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=2,
                           Date = DateTime.Now,
                       }
                   },
                   Task = new TaskDTO
                    {
                     Id = 2,
                     Name = "TestName",
                     Description  = "TestDescription",
                     Type = "TestType",
                     DateAdded = DateTime.Now,
                     DateCompleted = DateTime.Now,
                     Deadline = DateTime.Now,
                     Priority = 4,
                     UserId = 2
                    }
               },
               new TaskSetRecord
               {
                   Id = 3,
                   UserId = 3,
                   TaskOccurencies = new List<TaskDate>
                   {
                       new TaskDate
                       {
                           Id=3,
                           Date = DateTime.Now,
                       }
                   },
                   Task = new TaskDTO
                    {
                     Id = 3,
                     Name = "TestName",
                     Description  = "TestDescription",
                     Type = "TestType",
                     DateAdded = DateTime.Now,
                     DateCompleted = DateTime.Now,
                     Deadline = DateTime.Now,
                     Priority = 4,
                     UserId = 3
                    }
               }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TaskSetRecord>>();

            mockSet.As<IQueryable<TaskSetRecord>>().Setup(t => t.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TaskSetRecord>>().Setup(t => t.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TaskSetRecord>>().Setup(t => t.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TaskSetRecord>>().Setup(t => t.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
        [TestMethod]
        public void TaskSetDelete_Should_DeleteTaskSetRecord()
        {
            var mockSet = GetMockDbSet();
            var TaskSetRecordToDelete = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSetRecords).Returns(mockSet.Object);

            var service = new TaskSet_Delete(mockContext.Object, new MockLogger<Processor>());
            var result = service.Execute(JsonConvert.SerializeObject(TaskSetRecordToDelete));

            Assert.IsTrue(result != null);
            _ = result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskSetRecordToDelete), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [TestMethod]
        public void TaskSetPost_Should_PostTaskSetRecord()
        {
            var mockSet = new Mock<DbSet<TaskSetRecord>>();
            var TaskSetRecordToPost = new TaskSetDTO
            {
                Id = 1,
                UserId = 1,
                TaskOccurencies = new List<TaskDate> { new TaskDate() { Id = 1, Date = DateTime.Now } },
                Task = new TaskDTO
                {
                    Id = 3,
                    Name = "TestName",
                    Description = "TestDescription",
                    Type = "TestType",
                    DateAdded = DateTime.Now,
                    DateCompleted = DateTime.Now,
                    Deadline = DateTime.Now,
                    Priority = 4,
                    UserId = 3
                }
            };

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSetRecords).Returns(mockSet.Object);

            var service = new TaskSet_Post(mockContext.Object, new MockLogger<Processor>());
            var result = service.Execute(JsonConvert.SerializeObject(TaskSetRecordToPost));

            Assert.IsTrue(result != null);
            _ = result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<TaskSetRecord>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [TestMethod]
        public void TaskSetUpdate_Should_UpdateTaskSetRecord()
        {
            var mockSet = GetMockDbSet();
            var TaskSetRecordToUpdate = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskSetRecords).Returns(mockSet.Object);

            var service = new TaskSet_Update(mockContext.Object, new MockLogger<Processor>());
            var result = service.Execute(JsonConvert.SerializeObject(TaskSetRecordToUpdate));

            Assert.IsTrue(result != null);
            _ = result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskSetRecordToUpdate), Times.Once);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<TaskSetRecord>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }
    }
}