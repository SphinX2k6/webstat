using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002298 RID: 8856
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleTechTreeLevelItem : GridProxyAbstract<IMotorTechLevelPoint>
{
	// Token: 0x06010BE1 RID: 68577 RVA: 0x004966C1 File Offset: 0x004948C1
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x06010BE2 RID: 68578 RVA: 0x004966E4 File Offset: 0x004948E4
	[NullableContext(1)]
	public override void Refresh(IMotorTechLevelPoint data, bool isSelected, int gridIndex)
	{
		int targetLevel = data.TargetLevel;
		bool uiactive = data.CurLevel >= targetLevel;
		base.GetSprite(0).SetUIActive(uiactive);
	}

	// Token: 0x0200856B RID: 34155
	private class EMotorTechLevelItemComponent
	{
		// Token: 0x0402D262 RID: 184930
		public const int SprLevel = 0;
	}
}
