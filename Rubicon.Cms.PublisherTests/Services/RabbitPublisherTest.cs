using System;
using System.Collections.Generic;
using System.Text;

using Rubicon.Cms.Publisher.Services;

using Moq;

using Xunit;

namespace Rubicon.Cms.PublisherTests {
	public class RabbitPublisherTest {

		public class Publish {

			private Publisher.Services.Publisher publisher;
			private Mock<IPersister> mockPersister;
			

			public Publish () {
				mockPersister = new Mock<IPersister> ();
				mockPersister.Setup (x => x.Persist (It.IsAny<string> ()));

				publisher = new Publisher.Services.Publisher (mockPersister.Object);
			}

			[Fact (DisplayName = "When passed null content, it throws a ArgumentNullException")]
			public void NullContentThrowsArgumentNullException () {
				// Arrange
				Exception expected = null;

				// Act
				try {
					publisher.Publish (null);
				} catch (Exception e) {
					expected = e;
				}

				// Assert	
				Assert.IsType<ArgumentNullException> (expected);
			}

			[Fact (DisplayName = "when passed non-null content, it does not throw a ArgumentNullException")]
			public void ContentDoesNotThrow() {
				// Arrange
				Exception expected = null;

				// Act
				try {
					publisher.Publish ("content");
				} catch (Exception e) {
					expected = e;
				}

				// Assert	
				Assert.Null (expected);
				mockPersister.Verify (x => x.Persist (It.IsAny<string> ()), Times.Once ());
			}
		}
	}
}
