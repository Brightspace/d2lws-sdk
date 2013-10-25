using System;

namespace D2L.WS.SampleApp {
	[Serializable]
	public class Course {
		public CourseTemplate Template { get; set; }
		public CourseOffering Offering { get; set; }
	}
}
