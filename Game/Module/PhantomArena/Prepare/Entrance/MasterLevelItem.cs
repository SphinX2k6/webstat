using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054DE RID: 21726
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MasterLevelItem : AutoAttachItem<MasterLevelData>, IStaticVariableResetter
	{
		// Token: 0x060375A2 RID: 226722 RVA: 0x00E0BCC4 File Offset: 0x00E09EC4
		static MasterLevelItem()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(MasterLevelItem.CreateStaticDefaultValue), new Action(MasterLevelItem.ResetStaticDefaultValue));
		}

		// Token: 0x060375A3 RID: 226723 RVA: 0x00E0BCE3 File Offset: 0x00E09EE3
		public static void CreateStaticDefaultValue()
		{
			MasterLevelItem.ScaleCurve = null;
			MasterLevelItem.AlphaCurve = null;
		}

		// Token: 0x060375A4 RID: 226724 RVA: 0x00E0BCF1 File Offset: 0x00E09EF1
		public static void ResetStaticDefaultValue()
		{
			MasterLevelItem.ScaleCurve = null;
			MasterLevelItem.AlphaCurve = null;
		}

		// Token: 0x060375A5 RID: 226725 RVA: 0x00E0BD00 File Offset: 0x00E09F00
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(6, typeof(UUITexture)),
				new ValueTuple<int, Type>(7, typeof(UUITexture)),
				new ValueTuple<int, Type>(8, typeof(UUITexture)),
				new ValueTuple<int, Type>(9, typeof(UUIText)),
				new ValueTuple<int, Type>(10, typeof(UUIText)),
				new ValueTuple<int, Type>(11, typeof(UUIText)),
				new ValueTuple<int, Type>(12, typeof(UUITexture)),
				new ValueTuple<int, Type>(13, typeof(UUITexture)),
				new ValueTuple<int, Type>(14, typeof(UUIItem)),
				new ValueTuple<int, Type>(15, typeof(UUITexture)),
				new ValueTuple<int, Type>(16, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.SelectItem))
			};
		}

		// Token: 0x060375A6 RID: 226726 RVA: 0x00E0BEB9 File Offset: 0x00E0A0B9
		protected override void OnRefreshItem(MasterLevelData data)
		{
			if (data == null)
			{
				return;
			}
			this.Data = data;
			if (this.LevelSequencePlayer == null)
			{
				this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			}
			this.Refresh(data);
		}

		// Token: 0x060375A7 RID: 226727 RVA: 0x00E0BEE8 File Offset: 0x00E0A0E8
		[NullableContext(1)]
		private void Refresh(MasterLevelData data)
		{
			int level = data.Level;
			int masterLevelMax = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelMax(this.ActivityId);
			base.GetText(10).SetText(level.ToString(), true);
			base.GetText(11).SetText(level.ToString(), true);
			bool flag = ModelBase<PhantomArenaModel>.Instance.GetMasterLevel(this.ActivityId) < level;
			base.GetSprite(3).SetUIActive(!flag);
			base.GetText(10).SetUIActive(!flag);
			base.GetText(11).SetUIActive(flag);
			base.GetTexture(15).SetUIActive(!flag);
			base.GetTexture(8).SetUIActive(!flag);
			base.GetTexture(7).SetIsGray(flag);
			base.GetItem(14).SetUIActive(!flag);
			bool flag2 = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardList(level, this.ActivityId).Count == 0;
			bool masterLevelRewardIfTaken = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardIfTaken(level, this.ActivityId);
			bool masterLevelRewardCanTake = ModelBase<PhantomArenaModel>.Instance.GetMasterLevelRewardCanTake(level, this.ActivityId);
			base.GetItem(16).SetUIActive(!masterLevelRewardIfTaken && masterLevelRewardCanTake && !flag2);
			base.GetSprite(1).SetUIActive(level < masterLevelMax);
			base.GetSprite(2).SetUIActive(level < masterLevelMax);
			if (!data.IsMax)
			{
				int masterExpNow = ModelBase<PhantomArenaModel>.Instance.GetMasterExpNow(this.ActivityId, null);
				base.GetSprite(2).SetFillAmount((float)(masterExpNow - data.ExpLevel) / (float)data.ExpNext);
			}
		}

		// Token: 0x060375A8 RID: 226728 RVA: 0x00E0C079 File Offset: 0x00E0A279
		private void SelectItem()
		{
			if (this.CallbackOnSelect != null && this.Data != null)
			{
				this.CallbackOnSelect(this.Data.Level, this);
			}
		}

		// Token: 0x060375A9 RID: 226729 RVA: 0x00E0C0A2 File Offset: 0x00E0A2A2
		public override void OnSelect()
		{
			this.SelectItem();
		}

		// Token: 0x060375AA RID: 226730 RVA: 0x00E0C0AA File Offset: 0x00E0A2AA
		protected override void OnUnSelect()
		{
		}

		// Token: 0x060375AB RID: 226731 RVA: 0x00E0C0AC File Offset: 0x00E0A2AC
		protected override void OnMoveItem()
		{
			float currentMovePercentage = base.GetCurrentMovePercentage();
			float floatValue = MasterLevelItem.ScaleCurve.GetFloatValue(currentMovePercentage);
			base.GetItem(0).SetUIItemScale(new FVector(floatValue, floatValue, 1f));
			UUIItem item = base.GetItem(16);
			if (item != null)
			{
				item.SetUIItemScale(new FVector(1f / floatValue, 1f / floatValue, 1f));
			}
			float floatValue2 = MasterLevelItem.AlphaCurve.GetFloatValue(currentMovePercentage);
			base.GetItem(14).SetAlpha(floatValue2);
		}

		// Token: 0x060375AC RID: 226732 RVA: 0x00E0C129 File Offset: 0x00E0A329
		public MasterLevelItem() : base(null)
		{
		}

		// Token: 0x0401FCA2 RID: 130210
		private MasterLevelData Data;

		// Token: 0x0401FCA3 RID: 130211
		public int ActivityId;

		// Token: 0x0401FCA4 RID: 130212
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<int, MasterLevelItem> CallbackOnSelect;

		// Token: 0x0401FCA5 RID: 130213
		public static UCurveFloat ScaleCurve;

		// Token: 0x0401FCA6 RID: 130214
		public static UCurveFloat AlphaCurve;

		// Token: 0x0401FCA7 RID: 130215
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200B458 RID: 46168
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037D16 RID: 228630
			public const int PanelAnchor = 0;

			// Token: 0x04037D17 RID: 228631
			public const int SpriteBarBg = 1;

			// Token: 0x04037D18 RID: 228632
			public const int SpriteBar = 2;

			// Token: 0x04037D19 RID: 228633
			public const int SpriteStar = 3;

			// Token: 0x04037D1A RID: 228634
			public const int SpriteStarBg = 4;

			// Token: 0x04037D1B RID: 228635
			public const int BtnMain = 5;

			// Token: 0x04037D1C RID: 228636
			public const int IconBg1 = 6;

			// Token: 0x04037D1D RID: 228637
			public const int IconBg2 = 7;

			// Token: 0x04037D1E RID: 228638
			public const int IconBg4 = 8;

			// Token: 0x04037D1F RID: 228639
			public const int TextLv = 9;

			// Token: 0x04037D20 RID: 228640
			public const int TextLevel = 10;

			// Token: 0x04037D21 RID: 228641
			public const int TextLevelGray = 11;

			// Token: 0x04037D22 RID: 228642
			public const int IconNormal = 12;

			// Token: 0x04037D23 RID: 228643
			public const int IconSelect = 13;

			// Token: 0x04037D24 RID: 228644
			public const int PanelSelect = 14;

			// Token: 0x04037D25 RID: 228645
			public const int IconBg3 = 15;

			// Token: 0x04037D26 RID: 228646
			public const int ItemRedDot = 16;
		}
	}
}
