using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using TimeManager.ProcessingEngine.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TimeManager.ProcessingEngine.Processors;
using TimeManager.ProcessingEngine.Processors.TaskProcessors;
using TimeManager.ProcessingEngine.Tests.Data;
using Newtonsoft.Json;

namespace TimeManager.ProcessingEngine.Tests
{
    [TestClass]
    public class TaskProcTests
    {
        private Mock<DbSet<TaskRecords>> GetMockDbSet()
        {
            var data = new List<TaskRecords>()
            {
                new TaskRecords
                {
                    Id = 1,
                    TaskId = 1,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                },
                new TaskRecords
                {
                    Id = 2,
                    TaskId = 2,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                },
                new TaskRecords
                {
                    Id = 3,
                    TaskId = 3,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Priority = 4,
                    UserId = 1
                },
                new TaskRecords
                {
                    Id = 4,
                    TaskId = 4,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Priority = 4,
                    UserId = 3
                },
                new TaskRecords
                {
                    Id = 5,
                    TaskId = 5,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Priority = 4,
                    UserId = 2
                },
                new TaskRecords
                {
                    Id = 6,
                    TaskId = 6,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    Priority = 4,
                    UserId = 2
                }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<TaskRecords>>();

            mockSet.As<IQueryable<TaskRecords>>().Setup(t => t.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TaskRecords>>().Setup(t => t.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TaskRecords>>().Setup(t => t.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TaskRecords>>().Setup(t => t.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
        [TestMethod]
        public void TaskDelete_Should_DeleteTaskRecord()
        {
            var mockSet = GetMockDbSet();
            var TaskRecordToDelete = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);
            var TaskDTOToDelete = new TaskDTO
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Type = "TestType",
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                Priority = 4,
                UserId = 1
            };

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskRecords).Returns(mockSet.Object);

            var service = new Task_Delete(mockContext.Object, new MockLogger<Processor>());
            var result = service.Execute(JsonConvert.SerializeObject(TaskDTOToDelete));

            Assert.IsTrue(result != null);
            _ = result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskRecordToDelete), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [TestMethod]
        public void TaskPost_Should_PostTaskRecord()
        {
            var mockSet = new Mock<DbSet<TaskRecords>>();
            var TaskRecordToPost = new TaskDTO
            {
                Id = 1,
                Name = "TestName",
                Description = "TestDescription",
                Type = "TestType",
                DateAdded = DateTime.Now,
                DateCompleted = DateTime.Now,
                Deadline = DateTime.Now,
                Priority = 4,
                UserId = 1
            };

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskRecords).Returns(mockSet.Object);

            var service = new Task_Post(mockContext.Object, new MockLogger<Processor>());
            var result = service.Execute(JsonConvert.SerializeObject(TaskRecordToPost));

            Assert.IsTrue(result != null);
            _ = result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<TaskRecords>()), Times.Once);
                mockContext.Verify(tsk => tsk.SaveChanges(), Times.Once);
                return true;
            }, exception =>
            {
                Assert.Fail(exception.Message);
                return false;
            });
        }

        [TestMethod]
        public void TaskUpdate_Should_UpdateTaskRecord()
        {
            var mockSet = GetMockDbSet();
            var TaskRecordToUpdate = mockSet.Object.Single(tsk => tsk.Id == 1 && tsk.UserId == 1);

            var mockContext = new Mock<DataContext>();
            mockContext.Setup(t => t.TaskRecords).Returns(mockSet.Object);

            var service = new Task_Update(mockContext.Object, new MockLogger<Processor>());
            var result = service.Execute(JsonConvert.SerializeObject(TaskRecordToUpdate));

            Assert.IsTrue(result != null);
            _ = result.Match<bool>(succ =>
            {
                Assert.IsTrue(succ);
                mockSet.Verify(tsk => tsk.Remove(TaskRecordToUpdate), Times.Once);
                mockSet.Verify(tsk => tsk.Add(It.IsAny<TaskRecords>()), Times.Once);
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