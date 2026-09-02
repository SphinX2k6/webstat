using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E5B RID: 20059
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseBdBuffSelectBdItem : GridProxyAbstract<TrapDefenseBdData>
	{
		// Token: 0x06033D5A RID: 212314 RVA: 0x00CF61A4 File Offset: 0x00CF43A4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 16;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggleSelf));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033D5B RID: 212315 RVA: 0x00CF6420 File Offset: 0x00CF4620
		protected override UniTask OnBeforeStartAsync()
		{
			TrapDefenseBdBuffSelectBdItem.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdBuffSelectBdItem.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06033D5C RID: 212316 RVA: 0x00CF6463 File Offset: 0x00CF4663
		protected override void OnStart()
		{
			this.SequenceItem = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x06033D5D RID: 212317 RVA: 0x00CF6476 File Offset: 0x00CF4676
		protected override void OnBeforeDestroy()
		{
		}

		// Token: 0x06033D5E RID: 212318 RVA: 0x00CF6478 File Offset: 0x00CF4678
		public void UpdateDataBase(TrapDefenseBdData data)
		{
			this.ItemData = data;
			UUITexture texture = base.GetTexture(3);
			base.SetTextureByPath(data.Config.IconSmall, texture, null, null);
			UUIText text = base.GetText(4);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(data.Config.Name);
		}

		// Token: 0x06033D5F RID: 212319 RVA: 0x00CF64CC File Offset: 0x00CF46CC
		public override void Refresh(TrapDefenseBdData data, bool isSelected, int gridIndex)
		{
			this.UpdateDataBase(data);
			this.UpdateProgressValue(null, null, null);
			this.UpdateQualityShow();
			this.CheckBdActiveNewQuality(true);
		}

		// Token: 0x06033D60 RID: 212320 RVA: 0x00CF6510 File Offset: 0x00CF4710
		public void RefreshItem(TrapDefenseBdData data)
		{
			this.UpdateDataBase(data);
			this.UpdateProgressValue(null, null, null);
			this.UpdateQualityShow();
			this.CheckBdActiveNewQuality(false);
		}

		// Token: 0x06033D61 RID: 212321 RVA: 0x00CF6554 File Offset: 0x00CF4754
		public void RefreshCheckProgress(TrapDefenseBdData data)
		{
			this.UpdateDataBase(data);
			this.CheckBdActiveNewQuality(false);
			if (this.ItemData.PreAddedBuffIsActiveNewQuality(0).Item1)
			{
				int value = this.ItemData.GetCurrentActiveProgressNum() - 1;
				this.UpdateProgressValue(new int?(value), new int?(1), new int?(-1));
			}
			else
			{
				this.UpdateProgressValue(null, null, null);
			}
			this.UpdateQualityShow();
		}

		// Token: 0x06033D62 RID: 212322 RVA: 0x00CF65D4 File Offset: 0x00CF47D4
		public void UpdateProgressValue(int? curNum = null, int? addNum = null, int? addSum = null)
		{
			UUIText text = base.GetText(5);
			int num = curNum ?? this.ItemData.GetCurrentActiveProgressNum();
			int num2 = addNum ?? ((this.ItemData.PreAddedBdBuffData != null) ? 1 : 0);
			string text2;
			if (num2 <= 0)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(num);
				defaultInterpolatedStringHandler.AppendLiteral("+");
				defaultInterpolatedStringHandler.AppendFormatted<int>(num2);
				text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			string newText = text2;
			text.SetText(newText, true);
			int sumProgressForStageMode = this.ItemData.GetSumProgressForStageMode(addSum.GetValueOrDefault());
			UUIText text3 = base.GetText(6);
			if (text3 != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(sumProgressForStageMode);
				text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			float fillAmount = (sumProgressForStageMode == 0) ? 0f : ((float)num / (float)sumProgressForStageMode);
			UUISprite sprite = base.GetSprite(8);
			if (sprite != null)
			{
				sprite.SetFillAmount(fillAmount);
			}
			UUISprite sprite2 = base.GetSprite(10);
			if (sprite2 != null)
			{
				sprite2.SetFillAmount(fillAmount);
			}
			float num3 = (sumProgressForStageMode == 0) ? 0f : ((float)(num + num2) / (float)sumProgressForStageMode);
			UUISprite sprite3 = base.GetSprite(7);
			if (sprite3 != null)
			{
				sprite3.SetFillAmount(num3);
			}
			UUISprite sprite4 = base.GetSprite(9);
			if (sprite4 != null)
			{
				sprite4.SetFillAmount(num3);
			}
			this.IsUpStage = (num3 == 1f && num2 > 0);
			if (this.IsUpStage)
			{
				LevelSequencePlayer sequenceItem = this.SequenceItem;
				if (sequenceItem == null)
				{
					return;
				}
				sequenceItem.PlaySequencePurely("Loop", false, false, null, null, false);
				return;
			}
			else
			{
				LevelSequencePlayer sequenceItem2 = this.SequenceItem;
				if (sequenceItem2 == null)
				{
					return;
				}
				sequenceItem2.StopSequenceByKey("Loop", false, false);
				return;
			}
		}

		// Token: 0x06033D63 RID: 212323 RVA: 0x00CF6798 File Offset: 0x00CF4998
		private void UpdateQualityShow()
		{
			ValueTuple<bool, ETrapDefenseBdBuffQuality> valueTuple = this.ItemData.PreAddedBuffIsActiveNewQuality(-1);
			bool item = valueTuple.Item1;
			ETrapDefenseBdBuffQuality item2 = valueTuple.Item2;
			bool flag = item && this.IsUpStage;
			this.Quality = item2;
			if (item2 == ETrapDefenseBdBuffQuality.Purple)
			{
				this.SetProgressShowStateGold(!flag, false, true);
				this.SetProgressShowStatePurple(flag, true, false);
				return;
			}
			if (item2 == ETrapDefenseBdBuffQuality.Gold)
			{
				this.SetProgressShowStatePurple(false, false, false);
				this.SetProgressShowStateGold(true, true, false);
				return;
			}
			this.SetProgressShowStateGold(false, false, false);
			this.SetProgressShowStatePurple(true, false, true);
		}

		// Token: 0x06033D64 RID: 212324 RVA: 0x00CF6818 File Offset: 0x00CF4A18
		public void SetProgressShowStatePurple(bool show, bool showBg = false, bool useColor = false)
		{
			UUISprite sprite = base.GetSprite(8);
			if (sprite != null)
			{
				sprite.SetUIActive(show);
			}
			if (sprite != null)
			{
				UUIItem uuiitem = sprite;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem.SetChangeColor(useColor, fcolor);
			}
			UUIItem item = base.GetItem(2);
			if (item != null)
			{
				item.SetUIActive(showBg);
			}
			UUISprite sprite2 = base.GetSprite(7);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(show);
			}
			UUIItem item2 = base.GetItem(11);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(show);
		}

		// Token: 0x06033D65 RID: 212325 RVA: 0x00CF6888 File Offset: 0x00CF4A88
		public void SetProgressShowStateGold(bool show, bool showBg = false, bool useColor = false)
		{
			UUISprite sprite = base.GetSprite(10);
			if (sprite != null)
			{
				sprite.SetUIActive(show);
			}
			if (sprite != null)
			{
				UUIItem uuiitem = sprite;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem.SetChangeColor(useColor, fcolor);
			}
			UUIItem item = base.GetItem(1);
			if (item != null)
			{
				item.SetUIActive(showBg);
			}
			UUISprite sprite2 = base.GetSprite(9);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(show);
			}
			UUIItem item2 = base.GetItem(12);
			if (item2 == null)
			{
				return;
			}
			item2.SetUIActive(show);
		}

		// Token: 0x06033D66 RID: 212326 RVA: 0x00CF68FA File Offset: 0x00CF4AFA
		public UUIExtendToggle GetSelfToggle()
		{
			return base.GetExtendToggle(0);
		}

		// Token: 0x06033D67 RID: 212327 RVA: 0x00CF6903 File Offset: 0x00CF4B03
		private void OnClickToggleSelf(EToggleState state)
		{
			Action<TrapDefenseBdData> clickCallBack = this.ClickCallBack;
			if (clickCallBack != null)
			{
				clickCallBack(this.ItemData);
			}
			this.GetSelfToggle().SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x06033D68 RID: 212328 RVA: 0x00CF692C File Offset: 0x00CF4B2C
		public UniTask CheckPlayUpStageEffect()
		{
			TrapDefenseBdBuffSelectBdItem.<CheckPlayUpStageEffect>d__21 <CheckPlayUpStageEffect>d__;
			<CheckPlayUpStageEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CheckPlayUpStageEffect>d__.<>4__this = this;
			<CheckPlayUpStageEffect>d__.<>1__state = -1;
			<CheckPlayUpStageEffect>d__.<>t__builder.Start<TrapDefenseBdBuffSelectBdItem.<CheckPlayUpStageEffect>d__21>(ref <CheckPlayUpStageEffect>d__);
			return <CheckPlayUpStageEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06033D69 RID: 212329 RVA: 0x00CF6970 File Offset: 0x00CF4B70
		public void CheckBdActiveNewQuality(bool isCheckPre = false)
		{
			if (isCheckPre && this.ItemData.PreAddedBdBuffData == null)
			{
				this.BtnTagTips.SetActive(false);
				return;
			}
			ValueTuple<bool, ETrapDefenseBdBuffQuality> valueTuple = this.ItemData.PreAddedBuffIsActiveNewQuality(-1);
			bool item = valueTuple.Item1;
			ETrapDefenseBdBuffQuality item2 = valueTuple.Item2;
			this.BtnTagTips.SetActive(item);
			if (item)
			{
				this.BtnTagTips.UpdateQuality(item2);
				this.BtnTagTips.UpdateDescForBuffSelect(item2);
			}
		}

		// Token: 0x0401DFC5 RID: 122821
		public TrapDefenseBdData ItemData;

		// Token: 0x0401DFC6 RID: 122822
		public Action<TrapDefenseBdData> ClickCallBack;

		// Token: 0x0401DFC7 RID: 122823
		public LevelSequencePlayer SequenceItem;

		// Token: 0x0401DFC8 RID: 122824
		public bool IsUpStage;

		// Token: 0x0401DFC9 RID: 122825
		public ETrapDefenseBdBuffQuality Quality = ETrapDefenseBdBuffQuality.Purple;

		// Token: 0x0401DFCA RID: 122826
		public TrapDefenseBtnTagTips BtnTagTips;

		// Token: 0x0200AE00 RID: 44544
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04036092 RID: 221330
			public const int ToggleSelf = 0;

			// Token: 0x04036093 RID: 221331
			public const int ItemBgGold = 1;

			// Token: 0x04036094 RID: 221332
			public const int ItemBgPurple = 2;

			// Token: 0x04036095 RID: 221333
			public const int TextureIcon = 3;

			// Token: 0x04036096 RID: 221334
			public const int TextName = 4;

			// Token: 0x04036097 RID: 221335
			public const int TextProgress = 5;

			// Token: 0x04036098 RID: 221336
			public const int TextSumProgress = 6;

			// Token: 0x04036099 RID: 221337
			public const int SpriteProgressAddPurple = 7;

			// Token: 0x0403609A RID: 221338
			public const int SpriteProgressPurple = 8;

			// Token: 0x0403609B RID: 221339
			public const int SpriteProgressAddGold = 9;

			// Token: 0x0403609C RID: 221340
			public const int SpriteProgressGold = 10;

			// Token: 0x0403609D RID: 221341
			public const int ItemProgressBgPurple = 11;

			// Token: 0x0403609E RID: 221342
			public const int ItemProgressBgGold = 12;

			// Token: 0x0403609F RID: 221343
			public const int ItemUpStageEffectGold = 13;

			// Token: 0x040360A0 RID: 221344
			public const int ItemUpStageEffectPurple = 14;

			// Token: 0x040360A1 RID: 221345
			public const int ItemTagTip = 15;
		}
	}
}
