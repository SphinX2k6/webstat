using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D98 RID: 7576
public class TrapDefenseRoutePointView : UiPanelBase
{
	// Token: 0x0600DF3A RID: 57146 RVA: 0x003C0FB0 File Offset: 0x003BF1B0
	protected override void OnBeforeShow()
	{
		UUIItem sprite = base.GetSprite(0);
		int trapDefenseRoutePointNum = ConfigBase<TrapDefenseConfig>.Instance.GetTrapDefenseRoutePointNum();
		sprite.SetAlpha((float)(trapDefenseRoutePointNum - this.Index) / (float)trapDefenseRoutePointNum);
		this.RootItem.SetAlpha(0f);
	}

	// Token: 0x0600DF3B RID: 57147 RVA: 0x003C0FF0 File Offset: 0x003BF1F0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite))
		};
	}

	// Token: 0x0600DF3C RID: 57148 RVA: 0x003C1014 File Offset: 0x003BF214
	[NullableContext(1)]
	public void UpdatePosition(FVector worldPosition, float scale, Vector2D centerOffset)
	{
		if (!base.IsShow)
		{
			return;
		}
		this.RootItem.SetAlpha(1f);
		Vector vector = Vector.Create((double)worldPosition.X, (double)worldPosition.Y, (double)worldPosition.Z);
		vector.Multiply(TrapDefenseDefine.worldToTrapDefenseUiUnit, vector);
		Vector2D vector2D = Vector2D.Create(vector.X, vector.Y);
		vector2D.Multiply((double)scale, vector2D).Subtraction(centerOffset, vector2D);
		base.GetRootItem().SetAnchorOffset(vector2D.ToUeVector2D(false));
	}

	// Token: 0x04006B57 RID: 27479
	public double StartTimestamp;

	// Token: 0x04006B58 RID: 27480
	public int Index;

	// Token: 0x0200812E RID: 33070
	private static class EChildComponent
	{
		// Token: 0x0402BE85 RID: 179845
		public const int Icon = 0;
	}
}
