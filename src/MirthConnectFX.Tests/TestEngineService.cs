﻿using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace MirthConnectFX.Tests
{
    public class TestEngineService : TestContext
    {
        [Test]
        public void Deploy_DeploysChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";

            WithExpectedRequest(Operations.Engine.DeployChannels);

            var service = CreateService<EngineService, IEngineService>();
            service.DeployChannels(new List<string> { channelId });

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.ContainsKey("channelIds").Should().BeTrue();
            postData["channelIds"].Should().Contain(string.Format("<list><string>{0}</string></list>", channelId));
        }

        [Test]
        public void Undeploy_UndeploysChannel()
        {
            const string channelId = "2b0a4fe9-98c7-44b3-8f66-732dc18a300b";

            WithExpectedRequest(Operations.Engine.DeployChannels);

            var service = CreateService<EngineService, IEngineService>();
            service.UndeployChannels(new List<string> { channelId });

            var postData = RequestFactory.Requests.First().GetPostData();

            postData.ContainsKey("channelIds").Should().BeTrue();
            postData["channelIds"].Should().Contain(string.Format("<list><string>{0}</string></list>", channelId));
        }
    }
}