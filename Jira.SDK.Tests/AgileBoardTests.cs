﻿using Jira.SDK.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jira.SDK.Tests
{
	public class AgileBoardTests
	{
		[Fact]
		public void GetAgileBoardTest()
		{
			JiraEnvironment environment = new JiraEnvironment();
			environment.Connect(new MockJiraClient());

			List<AgileBoard> agileboards = environment.GetAgileBoards();

			Assert.NotNull(agileboards);
			Assert.Equal(3, agileboards.Count);
		}

		[Fact]
		public void GetSprintsFromAgileBoardTest()
		{
			JiraEnvironment environment = new JiraEnvironment();
			environment.Connect(new MockJiraClient());

			AgileBoard agileboard = environment.GetAgileBoards().First();
			Assert.Equal(1, agileboard.ID);

			List<Sprint> sprints = agileboard.GetSprints();

			Assert.NotNull(sprints);
			Assert.Equal(3, sprints.Count);
		}

		[Fact]
		public void GetIssuesFromSprintTest()
		{
			JiraEnvironment environment = new JiraEnvironment();
			environment.Connect(new MockJiraClient());

			//Get the first agile board
			AgileBoard agileboard = environment.GetAgileBoards().First();
			Assert.Equal(1, agileboard.ID);

			//Get the first sprint from the first agile board
			Sprint sprint = agileboard.GetSprints().First();
			Assert.Equal(1, sprint.ID);

			List<Issue> issues = sprint.GetIssues();
			Assert.NotNull(issues);
			Assert.Equal(4, issues.Count);
		}
	}
}
