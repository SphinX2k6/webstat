using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E29 RID: 20009
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseResultBdUnlockItem : GridProxyAbstract<ITrapDefenseResultUnlockInfo>
	{
		// Token: 0x06033B94 RID: 211860 RVA: 0x00CEDBD0 File Offset: 0x00CEBDD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClicked));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06033B95 RID: 211861 RVA: 0x00CEDD5E File Offset: 0x00CEBF5E
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(base.GetItem(8));
		}

		// Token: 0x06033B96 RID: 211862 RVA: 0x00CEDD74 File Offset: 0x00CEBF74
		public override void Refresh(ITrapDefenseResultUnlockInfo data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (data.Type == ETrapDefenseResultUnlockType.Organ || data.Type == ETrapDefenseResultUnlockType.OrganShare)
			{
				return;
			}
			TrapDefenseBdData trapDefenseBdData = ModelBase<TrapDefenseModel>.Instance.RougeModeData.BdDataMap[data.Id];
			bool valueOrDefault = data.NeedUnlockBar.GetValueOrDefault();
			base.SetTextureByPath(trapDefenseBdData.Config.Icon, base.GetTexture(5), null, null);
			UUIText text = base.GetText(6);
			if (text != null)
			{
				text.SetUIActive(valueOrDefault || data.ForShare.GetValueOrDefault());
			}
			UUIItem item = base.GetItem(7);
			if (item != null)
			{
				item.SetUIActive(data.IsFinish.GetValueOrDefault());
			}
			UUIItem item2 = base.GetItem(8);
			if (item2 != null)
			{
				item2.SetUIActive(data.IsNewUnlock.GetValueOrDefault());
			}
			this.Data.IsNewUnlock = null;
			if (!valueOrDefault)
			{
				this.SetGoldActive(false, null);
				this.SetPurpleActive(false, null, null);
				if (trapDefenseBdData != null && data.ForShare.GetValueOrDefault())
				{
					int currentActiveProgressNum = trapDefenseBdData.GetCurrentActiveProgressNum();
					UUIText text2 = base.GetText(6);
					if (text2 == null)
					{
						return;
					}
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(currentActiveProgressNum);
					text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
				return;
			}
			if (trapDefenseBdData != null)
			{
				this.SetProgress(trapDefenseBdData);
			}
		}

		// Token: 0x06033B97 RID: 211863 RVA: 0x00CEDEE0 File Offset: 0x00CEC0E0
		private void SetProgress(TrapDefenseBdData bdData)
		{
			int currentActiveProgressNum = bdData.GetCurrentActiveProgressNum();
			int sumProgressForStageMode = bdData.GetSumProgressForStageMode(0);
			ETrapDefenseBdBuffQuality curActiveQualityPool = bdData.GetCurActiveQualityPool();
			float value = (sumProgressForStageMode == 0) ? 0f : ((float)currentActiveProgressNum / (float)sumProgressForStageMode);
			if (this.Data.ForShare.GetValueOrDefault())
			{
				UUIText text = base.GetText(6);
				if (text != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
					defaultInterpolatedStringHandler.AppendFormatted<int>(currentActiveProgressNum);
					text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
			}
			else
			{
				UUIText text2 = base.GetText(6);
				if (text2 != null)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(currentActiveProgressNum);
					defaultInterpolatedStringHandler.AppendLiteral("/");
					defaultInterpolatedStringHandler.AppendFormatted<int>(sumProgressForStageMode);
					text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
				}
			}
			if (curActiveQualityPool == ETrapDefenseBdBuffQuality.Purple)
			{
				this.SetPurpleActive(true, new float?(value), new bool?(false));
				return;
			}
			if (curActiveQualityPool == ETrapDefenseBdBuffQuality.Gold)
			{
				this.SetGoldActive(true, new float?(value));
				return;
			}
			this.SetPurpleActive(true, new float?(value), new bool?(true));
		}

		// Token: 0x06033B98 RID: 211864 RVA: 0x00CEDFD4 File Offset: 0x00CEC1D4
		private void SetGoldActive(bool show, float? amount = null)
		{
			UUISprite sprite = base.GetSprite(1);
			UUISprite sprite2 = base.GetSprite(4);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(show);
			}
			if (sprite != null)
			{
				sprite.SetUIActive(show);
			}
			if (amount != null && amount.GetValueOrDefault() != 0f && sprite != null)
			{
				sprite.SetFillAmount(amount.Value);
			}
		}

		// Token: 0x06033B99 RID: 211865 RVA: 0x00CEE030 File Offset: 0x00CEC230
		private void SetPurpleActive(bool show, float? amount = null, bool? useColor = null)
		{
			UUISprite sprite = base.GetSprite(2);
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(show);
			}
			if (sprite != null)
			{
				sprite.SetUIActive(show);
			}
			if (useColor.GetValueOrDefault() && sprite != null)
			{
				UUIItem uuiitem = sprite;
				bool value = useColor.Value;
				FColor? fcolor = new FColor?(sprite.changeColor);
				uuiitem.SetChangeColor(value, fcolor);
			}
			if (amount != null && amount.GetValueOrDefault() != 0f && sprite != null)
			{
				sprite.SetFillAmount(amount.Value);
			}
		}

		// Token: 0x06033B9A RID: 211866 RVA: 0x00CEE0B0 File Offset: 0x00CEC2B0
		private void OnClicked()
		{
			if (this.Data.Type == ETrapDefenseResultUnlockType.Organ)
			{
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.TrapDefenseBuildingGangsInfoView, this.Data.Id, null);
		}

		// Token: 0x06033B9B RID: 211867 RVA: 0x00CEE0E0 File Offset: 0x00CEC2E0
		public void PlayUnlockAnim()
		{
			if (this.Data.Type != ETrapDefenseResultUnlockType.Bd)
			{
				return;
			}
			this.LevelSequencePlayer.PlayOrReplaySequenceByName("Unlock", false, null);
		}

		// Token: 0x0401DF26 RID: 122662
		protected ITrapDefenseResultUnlockInfo Data;

		// Token: 0x0401DF27 RID: 122663
		protected TrapDefenseBuildingDevelopItemData OrganData;

		// Token: 0x0401DF28 RID: 122664
		protected LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200AD9F RID: 44447
		[NullableContext(0)]
		internal class EUnlockBd
		{
			// Token: 0x04035EA5 RID: 220837
			public const int Btn = 0;

			// Token: 0x04035EA6 RID: 220838
			public const int SpriteBarGold = 1;

			// Token: 0x04035EA7 RID: 220839
			public const int SpriteBarPurple = 2;

			// Token: 0x04035EA8 RID: 220840
			public const int SpriteBgPurple = 3;

			// Token: 0x04035EA9 RID: 220841
			public const int SpriteBgGold = 4;

			// Token: 0x04035EAA RID: 220842
			public const int TextureIcon = 5;

			// Token: 0x04035EAB RID: 220843
			public const int TxtNum = 6;

			// Token: 0x04035EAC RID: 220844
			public const int ItemFinish = 7;

			// Token: 0x04035EAD RID: 220845
			public const int UnlockItem = 8;
		}
	}
}
