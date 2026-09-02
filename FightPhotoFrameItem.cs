using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020025C3 RID: 9667
public class FightPhotoFrameItem : GridProxyAbstract<FightPhotoFrameStyle>
{
	// Token: 0x06012E56 RID: 77398 RVA: 0x0053A250 File Offset: 0x00538450
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

	// Token: 0x06012E57 RID: 77399 RVA: 0x0053A2E4 File Offset: 0x005384E4
	public override void Refresh(FightPhotoFrameStyle data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		base.SetTextureByPath(data.Picture, base.GetTexture(1), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), data.Name, Array.Empty<object>());
		ICameraConditionRecommend cameraConditionRecommend = ModelBase<FightPhotoModel>.Instance.GetCameraConditionRecommend();
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(cameraConditionRecommend.FrameIds.Contains(data.Id));
	}

	// Token: 0x06012E58 RID: 77400 RVA: 0x0053A361 File Offset: 0x00538561
	public override void OnSelected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06012E59 RID: 77401 RVA: 0x0053A378 File Offset: 0x00538578
	public override void OnDeselected(bool fireEvent)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012E5A RID: 77402 RVA: 0x0053A38F File Offset: 0x0053858F
	[NullableContext(1)]
	public override object GetKey(FightPhotoFrameStyle data, int displayIndex)
	{
		return data.Id;
	}

	// Token: 0x06012E5B RID: 77403 RVA: 0x0053A39D File Offset: 0x0053859D
	private void OnClickToggle(EToggleState state)
	{
		this.OnToggleClick(this.Data);
	}

	// Token: 0x040093A5 RID: 37797
	private FightPhotoFrameStyle Data;

	// Token: 0x040093A6 RID: 37798
	[Nullable(1)]
	public Action<FightPhotoFrameStyle> OnToggleClick = delegate(FightPhotoFrameStyle data)
	{
	};

	// Token: 0x02008924 RID: 35108
	private enum EFrameItemComponents
	{
		// Token: 0x0402E467 RID: 189543
		TogRoot,
		// Token: 0x0402E468 RID: 189544
		TexPreview,
		// Token: 0x0402E469 RID: 189545
		TextName,
		// Token: 0x0402E46A RID: 189546
		SpriteRecommend
	}
}
