using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006EA0 RID: 28320
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingGetItem : SliderItem
	{
		// Token: 0x06044AD5 RID: 281301 RVA: 0x011D9CB0 File Offset: 0x011D7EB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06044AD6 RID: 281302 RVA: 0x011D9DA0 File Offset: 0x011D7FA0
		protected override UniTask OnBeforeStartAsync()
		{
			FishingGetItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FishingGetItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06044AD7 RID: 281303 RVA: 0x011D9DE3 File Offset: 0x011D7FE3
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.FinishSequenceEvent), false);
		}

		// Token: 0x06044AD8 RID: 281304 RVA: 0x011D9E0E File Offset: 0x011D800E
		protected override void OnBeforeDestroy()
		{
			if (this.LevelSequencePlayer != null)
			{
				this.LevelSequencePlayer.Clear();
				this.LevelSequencePlayer = null;
			}
		}

		// Token: 0x06044AD9 RID: 281305 RVA: 0x011D9E2A File Offset: 0x011D802A
		[NullableContext(1)]
		private void FinishSequenceEvent(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				base.FinishPlayStart();
				return;
			}
			if (sequenceName == "Close")
			{
				base.FinishPlayEnd();
			}
		}

		// Token: 0x06044ADA RID: 281306 RVA: 0x011D9E54 File Offset: 0x011D8054
		protected override void PlayStart()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
		}

		// Token: 0x06044ADB RID: 281307 RVA: 0x011D9E7C File Offset: 0x011D807C
		public override void PlayEnd()
		{
			this.LevelSequencePlayer.PlayLevelSequenceByName("Close", false, null, false);
		}

		// Token: 0x06044ADC RID: 281308 RVA: 0x011D9EA4 File Offset: 0x011D80A4
		protected override void OnActiveStatusChange(bool value)
		{
		}

		// Token: 0x06044ADD RID: 281309 RVA: 0x011D9EA8 File Offset: 0x011D80A8
		public override UniTask AsyncLoadUiResource()
		{
			FishingGetItem.<AsyncLoadUiResource>d__13 <AsyncLoadUiResource>d__;
			<AsyncLoadUiResource>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<AsyncLoadUiResource>d__.<>4__this = this;
			<AsyncLoadUiResource>d__.<>1__state = -1;
			<AsyncLoadUiResource>d__.<>t__builder.Start<FishingGetItem.<AsyncLoadUiResource>d__13>(ref <AsyncLoadUiResource>d__);
			return <AsyncLoadUiResource>d__.<>t__builder.Task;
		}

		// Token: 0x06044ADE RID: 281310 RVA: 0x011D9EEC File Offset: 0x011D80EC
		[NullableContext(1)]
		public UniTask Refresh(DockyardItemBlockOriginalData data)
		{
			FishingGetItem.<Refresh>d__14 <Refresh>d__;
			<Refresh>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Refresh>d__.<>4__this = this;
			<Refresh>d__.data = data;
			<Refresh>d__.<>1__state = -1;
			<Refresh>d__.<>t__builder.Start<FishingGetItem.<Refresh>d__14>(ref <Refresh>d__);
			return <Refresh>d__.<>t__builder.Task;
		}

		// Token: 0x06044ADF RID: 281311 RVA: 0x011D9F38 File Offset: 0x011D8138
		private void RefreshQuality(int qualityId)
		{
			FishingQuality fishingQualityConfig = ConfigBase<FishingConfig>.Instance.GetFishingQualityConfig(qualityId);
			UUISprite bg = base.GetSprite(0);
			bg.SetUIActive(false);
			this.SetSpriteByPath(fishingQualityConfig.TexBg, bg, false, null, delegate(bool success)
			{
				bg.SetUIActive(true);
			});
			FColor color = FColor.FromHex(fishingQualityConfig.TxtColor);
			base.GetText(2).SetColor(color);
			bool flag = qualityId == 5;
			base.GetItem(4).SetUIActive(flag);
			base.GetItem(5).SetUIActive(!flag);
		}

		// Token: 0x040263BE RID: 156606
		private const int SPECIAL_QUALITY_ID = 5;

		// Token: 0x040263BF RID: 156607
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040263C0 RID: 156608
		protected DockyardItemBlockOriginalData Data;

		// Token: 0x040263C1 RID: 156609
		protected FishingGetTagItem TagItem;

		// Token: 0x0200CB6C RID: 52076
		[NullableContext(0)]
		private class EItemComponents
		{
			// Token: 0x0403E6D6 RID: 255702
			public const int SpriteBg = 0;

			// Token: 0x0403E6D7 RID: 255703
			public const int TexIcon = 1;

			// Token: 0x0403E6D8 RID: 255704
			public const int TxtName = 2;

			// Token: 0x0403E6D9 RID: 255705
			public const int TagItem = 3;

			// Token: 0x0403E6DA RID: 255706
			public const int PanelQuality1 = 4;

			// Token: 0x0403E6DB RID: 255707
			public const int PanelQuality2 = 5;
		}
	}
}
