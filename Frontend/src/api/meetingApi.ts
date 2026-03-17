import type { CourseOfferingMeeting } from '../types';
const baseUrl = 'http://localhost:5001/api/courses';

export async function fetchMeetings(
  courseId: number,
  offeringId: number
): Promise<CourseOfferingMeeting[]> {
  const res = await fetch(
    `${baseUrl}/${courseId}/offerings/${offeringId}/meetings`
  );
  if (!res.ok) throw new Error('Failed to fetch meetings');
  return res.json();
}
