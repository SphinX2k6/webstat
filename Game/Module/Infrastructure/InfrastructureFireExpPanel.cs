using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Infrastructure
{
	// Token: 0x02005C5A RID: 23642
	[NullableContext(1)]
	[Nullable(0)]
	public class InfrastructureFireExpPanel : UiPanelBase
	{
		// Token: 0x0603BBAC RID: 244652 RVA: 0x00F219F4 File Offset: 0x00F1FBF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 17;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickHelp));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603BBAD RID: 244653 RVA: 0x00F21C94 File Offset: 0x00F1FE94
		protected override void OnStart()
		{
			this.SeqPlayer = new LevelSequencePlayer(base.GetItem(16));
			this.SeqPlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			(base.GetItem(16).GetOwner() as AUIBaseActor).OnSequencePlayEvent.Bind(new Action<string, string>(this.SequenceEvent));
			this.RefreshActivityLevel(0, true);
		}

		// Token: 0x0603BBAE RID: 244654 RVA: 0x00F21CFD File Offset: 0x00F1FEFD
		public bool UpdateExp()
		{
			return this.RefreshActivityLevel(0, false);
		}

		// Token: 0x0603BBAF RID: 244655 RVA: 0x00F21D08 File Offset: 0x00F1FF08
		public void RefreshExpBeforeRoadBuilt(int roadId)
		{
			this.RefreshActivityLevel(ConfigBase<InfrastructureConfig>.Instance.GetRoadConfigById(roadId).Value.FireExpReward, true);
		}

		// Token: 0x0603BBB0 RID: 244656 RVA: 0x00F21D38 File Offset: 0x00F1FF38
		private bool RefreshActivityLevel(int expDiff = 0, bool disableSequence = false)
		{
			double num = Math.Pow(10.0, (double)(this.numEnum.Length - 1));
			List<int> currentFireExpArray = this.CurrentFireExpArray;
			this.CurrentFireExpArray = new List<int>();
			double num2 = (double)(ModelBase<InfrastructureModel>.Instance.FireExp - (long)expDiff);
			int i;
			for (i = 0; i < this.numEnum.Length; i++)
			{
				int item = (int)Math.Floor(num2 / num);
				this.CurrentFireExpArray.Add(item);
				num2 %= num;
				num /= 10.0;
			}
			bool flag = false;
			i = 0;
			bool flag2 = true;
			while (i < this.numEnum.Length)
			{
				UUIArtText artText = base.GetArtText(this.numEnum[i]);
				UUIArtText artText2 = base.GetArtText(this.preNumEnum[i]);
				UUIArtText artText3 = base.GetArtText(this.nextNumEnum[i]);
				int num3 = this.CurrentFireExpArray[i];
				flag2 = (flag2 && num3 == 0 && i < this.numEnum.Length - 1);
				if (flag2)
				{
					UUIItem uuiitem = artText;
					bool bUseChangeColor = true;
					FColor? fcolor = new FColor?(artText.changeColor);
					uuiitem.SetChangeColor(bUseChangeColor, fcolor);
				}
				else
				{
					UUIItem uuiitem2 = artText;
					bool bUseChangeColor2 = false;
					FColor? fcolor = new FColor?(artText.Color);
					uuiitem2.SetChangeColor(bUseChangeColor2, fcolor);
				}
				if (disableSequence)
				{
					artText.SetText(num3.ToString());
				}
				if ((i < currentFireExpArray.Count && num3 != currentFireExpArray[i]) || flag)
				{
					flag = true;
					artText2.SetText(((currentFireExpArray[i] + 9) % 10).ToString());
					artText3.SetText(((currentFireExpArray[i] + 1) % 10).ToString());
					if (!disableSequence)
					{
						this.SeqPlayer.PlayLevelSequenceByName(this.sequenceName[i], false, null, false);
					}
				}
				i++;
			}
			return flag;
		}

		// Token: 0x0603BBB1 RID: 244657 RVA: 0x00F21EF8 File Offset: 0x00F200F8
		public void SetOnClickHelpCb(Action cb)
		{
			this.OnClickHelpCb = cb;
		}

		// Token: 0x0603BBB2 RID: 244658 RVA: 0x00F21F01 File Offset: 0x00F20101
		public void SetOnDigitSequenceFinishCb(Action cb)
		{
			this.OnDigitSequenceFinishCb = cb;
		}

		// Token: 0x0603BBB3 RID: 244659 RVA: 0x00F21F0A File Offset: 0x00F2010A
		private void OnClickHelp()
		{
			Action onClickHelpCb = this.OnClickHelpCb;
			if (onClickHelpCb == null)
			{
				return;
			}
			onClickHelpCb();
		}

		// Token: 0x0603BBB4 RID: 244660 RVA: 0x00F21F1C File Offset: 0x00F2011C
		private void OnSequenceClose(string seqName)
		{
			if (this.sequenceName.Contains(seqName))
			{
				Action onDigitSequenceFinishCb = this.OnDigitSequenceFinishCb;
				if (onDigitSequenceFinishCb == null)
				{
					return;
				}
				onDigitSequenceFinishCb();
			}
		}

		// Token: 0x0603BBB5 RID: 244661 RVA: 0x00F21F3C File Offset: 0x00F2013C
		private void SequenceEvent(string seqName, string eventName)
		{
			if (this.sequenceName.Contains(seqName) && eventName == "On")
			{
				int num = this.sequenceName.IndexOf(seqName);
				int num2 = this.CurrentFireExpArray[num];
				base.GetArtText(this.numEnum[num]).SetText(num2.ToString());
			}
		}

		// Token: 0x04021933 RID: 137523
		private List<int> CurrentFireExpArray = new List<int>();

		// Token: 0x04021934 RID: 137524
		private LevelSequencePlayer SeqPlayer;

		// Token: 0x04021935 RID: 137525
		private Action OnClickHelpCb;

		// Token: 0x04021936 RID: 137526
		private Action OnDigitSequenceFinishCb;

		// Token: 0x04021937 RID: 137527
		private readonly int[] numEnum = new int[]
		{
			1,
			2,
			3,
			4,
			5
		};

		// Token: 0x04021938 RID: 137528
		private readonly int[] preNumEnum = new int[]
		{
			11,
			12,
			13,
			14,
			15
		};

		// Token: 0x04021939 RID: 137529
		private readonly int[] nextNumEnum = new int[]
		{
			6,
			7,
			8,
			9,
			10
		};

		// Token: 0x0402193A RID: 137530
		private readonly string[] sequenceName = new string[]
		{
			"FirstDigit",
			"SecondDigit",
			"ThirdDigit",
			"FourthDigit",
			"FifthDigit"
		};

		// Token: 0x0200BCDB RID: 48347
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x0403A2F1 RID: 238321
			public const int BtnHelp = 0;

			// Token: 0x0403A2F2 RID: 238322
			public const int ArtText1 = 1;

			// Token: 0x0403A2F3 RID: 238323
			public const int ArtText2 = 2;

			// Token: 0x0403A2F4 RID: 238324
			public const int ArtText3 = 3;

			// Token: 0x0403A2F5 RID: 238325
			public const int ArtText4 = 4;

			// Token: 0x0403A2F6 RID: 238326
			public const int ArtText5 = 5;

			// Token: 0x0403A2F7 RID: 238327
			public const int ArtTextNext1 = 6;

			// Token: 0x0403A2F8 RID: 238328
			public const int ArtTextNext2 = 7;

			// Token: 0x0403A2F9 RID: 238329
			public const int ArtTextNext3 = 8;

			// Token: 0x0403A2FA RID: 238330
			public const int ArtTextNext4 = 9;

			// Token: 0x0403A2FB RID: 238331
			public const int ArtTextNext5 = 10;

			// Token: 0x0403A2FC RID: 238332
			public const int ArtTextPre1 = 11;

			// Token: 0x0403A2FD RID: 238333
			public const int ArtTextPre2 = 12;

			// Token: 0x0403A2FE RID: 238334
			public const int ArtTextPre3 = 13;

			// Token: 0x0403A2FF RID: 238335
			public const int ArtTextPre4 = 14;

			// Token: 0x0403A300 RID: 238336
			public const int ArtTextPre5 = 15;

			// Token: 0x0403A301 RID: 238337
			public const int PanelSeq = 16;
		}
	}
}
