using UnityEngine;

public sealed class ScheduleElementsGenerator
{
    public Layer CreateScheduleElements(int elementsAmount, RandomScheduleElementsSettings generationSettings)
    {
        ScheduleElement[] elements = new ScheduleElement[elementsAmount];

        int currentTime = 0;

        for (int i = 0; i < elementsAmount; i++)
        {
            currentTime += Random.Range(generationSettings.MinSpacing, generationSettings.MaxSpacing);

            int startTime = currentTime;

            currentTime += Random.Range(generationSettings.MinElementDuration, generationSettings.MaxElementDuration);

            elements[i] = new ScheduleElement(startTime, currentTime);
        }
        
        int minTime = elements[0].StartTime;

        int maxTime = elements[elementsAmount - 1].EndTime;
    
        return new Layer(elements, minTime, maxTime);
    }
}
