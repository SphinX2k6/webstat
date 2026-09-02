using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CF2 RID: 7410
[NullableContext(2)]
[Nullable(0)]
public class RoleDescribeComponent : UiPanelBase
{
	// Token: 0x17001150 RID: 4432
	// (get) Token: 0x0600D98D RID: 55693 RVA: 0x003A5A92 File Offset: 0x003A3C92
	// (set) Token: 0x0600D98E RID: 55694 RVA: 0x003A5A9A File Offset: 0x003A3C9A
	public Action OnClickLookCallback { get; set; }

	// Token: 0x0600D98F RID: 55695 RVA: 0x003A5AA4 File Offset: 0x003A3CA4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnBtnLookClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600D990 RID: 55696 RVA: 0x003A5C10 File Offset: 0x003A3E10
	private void OnBtnLookClick()
	{
		Action onClickLookCallback = this.OnClickLookCallback;
		if (onClickLookCallback == null)
		{
			return;
		}
		onClickLookCallback();
	}

	// Token: 0x0600D991 RID: 55697 RVA: 0x003A5C24 File Offset: 0x003A3E24
	public void SetLookBtnActive(bool active)
	{
		UUIButtonComponent button = base.GetButton(6);
		if (button == null)
		{
			return;
		}
		UUIItem uuiitem = button.RootUIComp.Get();
		if (uuiitem == null)
		{
			return;
		}
		uuiitem.SetUIActive(active);
	}

	// Token: 0x0600D992 RID: 55698 RVA: 0x003A5C58 File Offset: 0x003A3E58
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(2));
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(true);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(false);
	}

	// Token: 0x0600D993 RID: 55699 RVA: 0x003A5CC8 File Offset: 0x003A3EC8
	public void Update(int gachaTextureInfoId, bool isUp = false)
	{
		this.GachaTextureInfoId = gachaTextureInfoId;
		RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(this.GachaTextureInfoId);
		if (roleInfoById == null)
		{
			return;
		}
		base.GetText(0).ShowTextNew(roleInfoById.Value.Name);
		ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(roleInfoById.Value.ElementId);
		UUITexture texture = base.GetTexture(3);
		UUISprite sprite = base.GetSprite(4);
		base.SetTextureByPath(elementConfig.Value.Icon, texture, null, null);
		this.SetSpriteByPath(elementConfig.Value.GachaElementBgSpritePath, sprite, false, null, null);
		this.UpdateQuality(roleInfoById.Value.QualityId);
		base.GetItem(1).SetUIActive(isUp);
	}

	// Token: 0x0600D994 RID: 55700 RVA: 0x003A5DA6 File Offset: 0x003A3FA6
	private void UpdateQuality(int quality)
	{
		this.StarLayout.RebuildLayout(quality);
	}

	// Token: 0x0600D995 RID: 55701 RVA: 0x003A5DB4 File Offset: 0x003A3FB4
	public void OpenRolePreview()
	{
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(this.GachaTextureInfoId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RoleHandBookRootView, gachaTextureInfo.Value.TrialId, null);
	}

	// Token: 0x0600D996 RID: 55702 RVA: 0x003A5DF6 File Offset: 0x003A3FF6
	public UUIItem GetJumpBtnRoot()
	{
		return base.GetItem(7);
	}

	// Token: 0x040067D2 RID: 26578
	private int GachaTextureInfoId;

	// Token: 0x040067D3 RID: 26579
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x040067D4 RID: 26580
	private SimpleGenericLayout StarLayout;

	// Token: 0x0200805C RID: 32860
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402BAA4 RID: 178852
		public const int RoleNameText = 0;

		// Token: 0x0402BAA5 RID: 178853
		public const int UpItem = 1;

		// Token: 0x0402BAA6 RID: 178854
		public const int StarLayout = 2;

		// Token: 0x0402BAA7 RID: 178855
		public const int AttrTexture = 3;

		// Token: 0x0402BAA8 RID: 178856
		public const int AttrBgSprite = 4;

		// Token: 0x0402BAA9 RID: 178857
		public const int AttrSprite = 5;

		// Token: 0x0402BAAA RID: 178858
		public const int BtnLook = 6;

		// Token: 0x0402BAAB RID: 178859
		public const int JumpBtnRoot = 7;
	}
}
