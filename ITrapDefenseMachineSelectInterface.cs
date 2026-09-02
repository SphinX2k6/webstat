using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x02001DA8 RID: 7592
[NullableContext(2)]
public interface ITrapDefenseMachineSelectInterface
{
	// Token: 0x0600E015 RID: 57365
	void SelectMachine(TrapDefenseBuildingDevelopItemData data);

	// Token: 0x0600E016 RID: 57366
	void SliderPointerDown();

	// Token: 0x0600E017 RID: 57367
	void SliderValueChange(TrapDefenseBuildingDevelopItemData data);

	// Token: 0x0600E018 RID: 57368
	void SliderDragEnd();
}
