﻿using LightBDD.Notification;
using LightBDD.UnitTests.Helpers;
using NUnit.Framework;
using Rhino.Mocks;

namespace LightBDD.UnitTests
{
	[TestFixture]
	[Description("some description")]
	public class BDD_runner_tests_with_dedicated_feature_description
	{
		[Test]
		public void Should_display_feature_name()
		{
			var progressNotifier = MockRepository.GenerateMock<IProgressNotifier>();
			new TestableBDDRunner(GetType(), progressNotifier);
			progressNotifier.AssertWasCalled(n => n.NotifyFeatureStart("BDD runner tests with dedicated feature description", "some description", null));
		}
	}
}