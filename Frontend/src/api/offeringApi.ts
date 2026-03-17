import type { CourseOffering } from '../types';
const baseUrl = 'http://localhost:5001/api/courses';

export async function fetchCourseOfferings(
  id: number
): Promise<CourseOffering[]> {
  const res = await fetch(`${baseUrl}/${id}/offerings`);
  if (!res.ok)
    throw new Error(`Failed to fetch course offerings with id ${id}`);
  return res.json();
}

export async function fetchCourseOfferingById(
  courseId: number,
  offeringId: number
): Promise<CourseOffering> {
  const res = await fetch(`${baseUrl}/${courseId}/offerings/${offeringId}`);
  if (!res.ok) throw new Error(`Failed to fetch offering ${offeringId}`);
  return res.json();
}
