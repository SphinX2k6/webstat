using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020025C6 RID: 9670
public class FightPhotoOptionItem : GridProxyAbstract<FightPhotoOption>
{
	// Token: 0x06012E6A RID: 77418 RVA: 0x0053A688 File Offset: 0x00538888
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06012E6B RID: 77419 RVA: 0x0053A71C File Offset: 0x0053891C
	public override void Refresh(FightPhotoOption data, bool isSelected, int gridIndex)
	{
		this.Data = new FightPhotoOption?(data);
		base.SetTextureByPath(data.Picture, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
		ICameraConditionRecommend cameraConditionRecommend = ModelBase<FightPhotoModel>.Instance.GetCameraConditionRecommend();
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(cameraConditionRecommend.FilterIds.Contains(data.Id));
	}

	// Token: 0x06012E6C RID: 77420 RVA: 0x0053A79E File Offset: 0x0053899E
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06012E6D RID: 77421 RVA: 0x0053A7B5 File Offset: 0x005389B5
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012E6E RID: 77422 RVA: 0x0053A7CC File Offset: 0x005389CC
	[NullableContext(1)]
	public override object GetKey(FightPhotoOption data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x06012E6F RID: 77423 RVA: 0x0053A7DA File Offset: 0x005389DA
	private void OnClickToggle(EToggleState state)
	{
		this.OnToggleClick(this.Data.Value);
	}

	// Token: 0x040093AA RID: 37802
	private FightPhotoOption? Data;

	// Token: 0x040093AB RID: 37803
	[Nullable(1)]
	public Action<FightPhotoOption> OnToggleClick = delegate(FightPhotoOption data)
	{
	};

	// Token: 0x0200892B RID: 35115
	private enum EComponents
	{
		// Token: 0x0402E483 RID: 189571
		ToggleRoot,
		// Token: 0x0402E484 RID: 189572
		TextureBg,
		// Token: 0x0402E485 RID: 189573
		TextName,
		// Token: 0x0402E486 RID: 189574
		SpriteRecommend
	}
}
