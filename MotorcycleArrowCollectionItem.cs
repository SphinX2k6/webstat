using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D30 RID: 7472
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleArrowCollectionItem : UiPanelBase
{
	// Token: 0x0600DC02 RID: 56322 RVA: 0x003B23A4 File Offset: 0x003B05A4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleRoot))
		};
	}

	// Token: 0x0600DC03 RID: 56323 RVA: 0x003B2490 File Offset: 0x003B0690
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleArrowCollectionItem.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleArrowCollectionItem.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DC04 RID: 56324 RVA: 0x003B24D4 File Offset: 0x003B06D4
	protected override void OnBeforeShow()
	{
		this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
	}

	// Token: 0x0600DC05 RID: 56325 RVA: 0x003B2500 File Offset: 0x003B0700
	public void UpdateData(MotorcycleArrowCollectionItemData collectionItemData, bool bRefresh)
	{
		this.CollectionData = collectionItemData;
		this.UpdateBgQuality();
		this.UpdateCollectionConfig();
		if (bRefresh)
		{
			this.SequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
		}
	}

	// Token: 0x0600DC06 RID: 56326 RVA: 0x003B2540 File Offset: 0x003B0740
	private void UpdateBgQuality()
	{
		base.SetTextureByPath(ConfigMotorFightQualityById.GetConfig(this.CollectionData.Config.Quality, true).Value.DetailCardBg, this.TextureQualityBg, null, null);
	}

	// Token: 0x0600DC07 RID: 56327 RVA: 0x003B258C File Offset: 0x003B078C
	private void UpdateCollectionConfig()
	{
		MotorFightItem config = this.CollectionData.Config;
		base.GetText(2).ShowTextNew(config.Name);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(this.TextCollectionDesc, config.Desc, config.DescParam());
		MotorFightItemType? collectionTypeConfigById = ConfigBase<MotorcycleArrowConfig>.Instance.GetCollectionTypeConfigById(config.Type);
		this.TextCollectionType.ShowTextNew(collectionTypeConfigById.Value.Name);
		this.SetSpriteByPath(collectionTypeConfigById.Value.Icon, this.SpriteTypeIcon, false, null, null);
		base.SetTextureByPath(config.IconBig, this.TextureIcon, null, null);
	}

	// Token: 0x0600DC08 RID: 56328 RVA: 0x003B2648 File Offset: 0x003B0848
	public void SetTextureBgByResId(string resId, UUITexture uiTexture)
	{
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
		base.SetTextureByPath(resourcePath, uiTexture, null, null);
	}

	// Token: 0x0600DC09 RID: 56329 RVA: 0x003B2674 File Offset: 0x003B0874
	public void SetSelect(bool select)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		EToggleState state = select ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x0600DC0A RID: 56330 RVA: 0x003B269E File Offset: 0x003B089E
	public void OnClickToggleRoot(EToggleState check)
	{
		Action<MotorcycleArrowCollectionItemData> onSelectCallback = this.OnSelectCallback;
		if (onSelectCallback == null)
		{
			return;
		}
		onSelectCallback(this.CollectionData);
	}

	// Token: 0x0400693A RID: 26938
	public MotorcycleArrowCollectionItemData CollectionData;

	// Token: 0x0400693B RID: 26939
	public UUITexture TextureQualityBg;

	// Token: 0x0400693C RID: 26940
	public UUIText TextTitle;

	// Token: 0x0400693D RID: 26941
	public UUITexture TextureIcon;

	// Token: 0x0400693E RID: 26942
	public UUIText TextCollectionType;

	// Token: 0x0400693F RID: 26943
	public UUISprite SpriteTypeIcon;

	// Token: 0x04006940 RID: 26944
	public UUIText TextCollectionDesc;

	// Token: 0x04006941 RID: 26945
	public UUIItem LockItem;

	// Token: 0x04006942 RID: 26946
	[Nullable(2)]
	private LevelSequencePlayer SequencePlayer;

	// Token: 0x04006943 RID: 26947
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleArrowCollectionItemData> OnSelectCallback;

	// Token: 0x020080BF RID: 32959
	[NullableContext(0)]
	private static class EComponentDefine
	{
		// Token: 0x0402BC8B RID: 179339
		public const int ToggleRoot = 0;

		// Token: 0x0402BC8C RID: 179340
		public const int TextureQualityBg = 1;

		// Token: 0x0402BC8D RID: 179341
		public const int TextTitle = 2;

		// Token: 0x0402BC8E RID: 179342
		public const int TextureIcon = 3;

		// Token: 0x0402BC8F RID: 179343
		public const int TextCollectionType = 4;

		// Token: 0x0402BC90 RID: 179344
		public const int SpriteTypeIcon = 5;

		// Token: 0x0402BC91 RID: 179345
		public const int TextCollectionDesc = 6;

		// Token: 0x0402BC92 RID: 179346
		public const int LockItem = 7;
	}
}
