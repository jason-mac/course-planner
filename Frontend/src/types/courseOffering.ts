import type { CourseOfferingMeeting } from './courseOfferingMeeting';

export interface CourseOffering {
  offeringId: number;
  courseId: number;
  term: string;
  section: string;
  meetings: CourseOfferingMeeting[];
}
