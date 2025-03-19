// See https://aka.ms/new-console-template for more information
using ProbabilityAndStatistics;

DataReceiver receiver = new DataReceiver();

receiver.SetData();
if (receiver.can == true)
{
    receiver.FrequencyTable();
    
    receiver.SystematicRandomSampling();

    receiver.FrequencySeries();

    receiver.SimpleSerialize();

    receiver.SetSimpleRandomSampling();
}


