using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020027A7 RID: 10151
public class RoleIconItem : UiPanelBase
{
	// Token: 0x060140B5 RID: 82101 RVA: 0x005985E0 File Offset: 0x005967E0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUISprite))
		};
	}

	// Token: 0x060140B6 RID: 82102 RVA: 0x00598650 File Offset: 0x00596850
	protected override void OnStart()
	{
		this.SequencePlayer = new UiSequencePlayer(this.RootItem);
	}

	// Token: 0x060140B7 RID: 82103 RVA: 0x00598664 File Offset: 0x00596864
	[NullableContext(1)]
	public void Refresh(RoleDataBase roleInstance)
	{
		this.QualityId = roleInstance.GetRoleConfig().QualityId;
		base.SetRoleIconByRoleIdOrSkinId(roleInstance.GetRoleConfig().RoleHeadIconBig, base.GetTexture(0), roleInstance.GetRoleId(), new int?(roleInstance.GetRoleSkinId()), null, new EUiViewName?(EUiViewName.RoleRootView));
		this.RefreshQualitySprite(this.QualityId);
		this.PlaySequenceByQualityId(this.QualityId);
	}

	// Token: 0x060140B8 RID: 82104 RVA: 0x005986D4 File Offset: 0x005968D4
	private void PlaySequenceByQualityId(int qualityId)
	{
		if (qualityId == 4)
		{
			this.SequencePlayer.PlaySequencePurely("Purple".ToString(), false, false);
			return;
		}
		if (qualityId == 5)
		{
			this.SequencePlayer.PlaySequencePurely("Yellow".ToString(), false, false);
		}
	}

	// Token: 0x060140B9 RID: 82105 RVA: 0x00598710 File Offset: 0x00596910
	public void PlaySelectSequence()
	{
		int qualityId = this.QualityId;
		if (qualityId == 4)
		{
			this.SequencePlayer.PlaySequencePurely("PurpleSelect".ToString(), false, false);
			return;
		}
		if (qualityId != 5)
		{
			return;
		}
		this.SequencePlayer.PlaySequencePurely("YellowSelect".ToString(), false, false);
	}

	// Token: 0x060140BA RID: 82106 RVA: 0x0059875C File Offset: 0x0059695C
	public void StopSelectSequence()
	{
		this.SequencePlayer.StopSequenceByKey("PurpleSelect".ToString(), false, false);
		this.SequencePlayer.StopSequenceByKey("YellowSelect".ToString(), false, false);
	}

	// Token: 0x060140BB RID: 82107 RVA: 0x0059878C File Offset: 0x0059698C
	private void RefreshQualitySprite(int qualityId)
	{
		UUISprite sprite = base.GetSprite(1);
		UUISprite sprite2 = base.GetSprite(2);
		UUISprite sprite3 = base.GetSprite(3);
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_RoleIconBgUnCheckedUnHoverNew");
		defaultInterpolatedStringHandler.AppendFormatted<int>(qualityId);
		string resourcePath = instance.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath, sprite3, false, null, null);
		UiResourceConfig instance2 = ConfigBase<UiResourceConfig>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_RoleIconBgUnCheckedHoverNew");
		defaultInterpolatedStringHandler.AppendFormatted<int>(qualityId);
		string resourcePath2 = instance2.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath2, sprite2, false, null, null);
		UiResourceConfig instance3 = ConfigBase<UiResourceConfig>.Instance;
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_RoleIconBgCheckedNew");
		defaultInterpolatedStringHandler.AppendFormatted<int>(qualityId);
		string resourcePath3 = instance3.GetResourcePath(defaultInterpolatedStringHandler.ToStringAndClear());
		this.SetSpriteByPath(resourcePath3, sprite, false, null, null);
	}

	// Token: 0x04009C33 RID: 39987
	private int QualityId;

	// Token: 0x04009C34 RID: 39988
	[Nullable(2)]
	private UiSequencePlayer SequencePlayer;

	// Token: 0x02008B62 RID: 35682
	private enum ERoleIconDefine
	{
		// Token: 0x0402EFC9 RID: 192457
		RoleIcon,
		// Token: 0x0402EFCA RID: 192458
		SpriteSelect,
		// Token: 0x0402EFCB RID: 192459
		SpriteHover,
		// Token: 0x0402EFCC RID: 192460
		SpriteNormal
	}
}
