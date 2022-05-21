﻿using DataverseEntities;
using FakeXrmEasy.Plugins;
using PowerAppsBootcamp.Plugins;
using System;
using System.Linq;
using Xunit;

namespace PowerAppsBootCamp.Plugins.Tests
{
    public class FollowUpPluginTests : FakeXrmEasyTestsBase
    {
        private readonly Contact _contact;

        public FollowUpPluginTests()
        {
            _contact = new Contact()
            {
                Id = Guid.NewGuid()
            };
        }

        [Fact]
        public void Should_create_follow_task_associated_with_the_contact()
        {
            var pluginContext = _context.GetDefaultPluginContext();
            pluginContext.OutputParameters.Add("id", _contact.Id.ToString());

            _context.ExecutePluginWithTarget<FollowUpPlugin>(pluginContext, _contact);

            var tasks = _context.CreateQuery<Task>().ToList();
            Assert.Single(tasks);

            Assert.Equal(_contact.Id, tasks[0].RegardingObjectId.Id);
        }
    }
}
