import type { MeetingType } from './meetingType.ts';
import type { Day } from './day.ts';

export interface CourseOfferingMeeting {
  meetingId: number;
  day: Day;
  startTime: string | null;
  endTime: string | null;
  location: string | null;
  type: MeetingType;
}
