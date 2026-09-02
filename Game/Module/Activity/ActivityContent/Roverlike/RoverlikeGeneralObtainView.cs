using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063D1 RID: 25553
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeGeneralObtainView : RoverlikeActionViewBase
	{
		// Token: 0x0604027F RID: 262783 RVA: 0x01070DDC File Offset: 0x0106EFDC
		public RoverlikeGeneralObtainView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06040280 RID: 262784 RVA: 0x01070DF0 File Offset: 0x0106EFF0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUISprite));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnBtnCloseClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06040281 RID: 262785 RVA: 0x01070FA0 File Offset: 0x0106F1A0
		protected override void OnStart()
		{
			Dictionary<int, UUIItem> dictionary = new Dictionary<int, UUIItem>();
			dictionary[0] = base.GetItem(3);
			dictionary[2] = base.GetItem(4);
			dictionary[1] = base.GetItem(5);
			Dictionary<int, UUIItem> templateItems = dictionary;
			this.MultiList = new MultiTemplateComponent(base.GetItem(2), templateItems);
			this.RefreshObtainList(false);
		}

		// Token: 0x06040282 RID: 262786 RVA: 0x01070FF8 File Offset: 0x0106F1F8
		private List<IMultiTemplateGridData> BuildDataList(List<RoverlikeGainEntry> entries)
		{
			List<IMultiTemplateGridData> list = new List<IMultiTemplateGridData>();
			foreach (RoverlikeGainEntry roverlikeGainEntry in entries)
			{
				switch (roverlikeGainEntry.Type)
				{
				case RoverRogueGainDataType.RoverRogueGainBless:
				{
					RoverlikeBlessingItemData data = new RoverlikeBlessingItemData
					{
						BlessId = roverlikeGainEntry.ConfigId,
						IncId = new int?(roverlikeGainEntry.IncId),
						AllowToggleInteract = new bool?(false)
					};
					list.Add(new RoverlikeGeneralObtainView.AttributeGridData
					{
						Data = data
					});
					continue;
				}
				case RoverRogueGainDataType.RoverRogueGainRoleEnhance:
				{
					RoverlikeReinforcementItemData data2 = new RoverlikeReinforcementItemData
					{
						ConfigId = roverlikeGainEntry.ConfigId,
						IncId = new int?(roverlikeGainEntry.IncId),
						AllowToggleInteract = new bool?(false)
					};
					list.Add(new RoverlikeGeneralObtainView.ReinforcementGridData
					{
						Data = data2
					});
					continue;
				}
				case RoverRogueGainDataType.RoverRogueGainItem:
				{
					RoverlikePropItemData data3 = new RoverlikePropItemData
					{
						ConfigId = roverlikeGainEntry.ConfigId,
						IncId = new int?(roverlikeGainEntry.IncId),
						IsInGame = true
					};
					list.Add(new RoverlikeGeneralObtainView.PropGridData
					{
						Data = data3
					});
					continue;
				}
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Roverlike;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[俯视角肉鸽] 通用获得界面不支持该类型Entry";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", roverlikeGainEntry.Type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return list;
		}

		// Token: 0x06040283 RID: 262787 RVA: 0x01071190 File Offset: 0x0106F390
		public void RefreshObtainList(bool isFirst = true)
		{
			IRoverlikeGeneralObtainParam roverlikeGeneralObtainParam = ModelBase<RoverlikeModel>.Instance.ActionData.PopObtainParam();
			if (roverlikeGeneralObtainParam == null)
			{
				base.CloseMe(null);
				return;
			}
			this.ScrollDataList.Clear();
			this.ScrollDataList.AddRange(this.BuildDataList(roverlikeGeneralObtainParam.Entries));
			this.RefreshAnim(roverlikeGeneralObtainParam.IsLose);
			MultiTemplateComponent multiList = this.MultiList;
			if (multiList != null)
			{
				multiList.RefreshByData(this.ScrollDataList, true);
			}
			this.RefreshStyle(roverlikeGeneralObtainParam.IsLose);
			this.RefreshTitle(roverlikeGeneralObtainParam.IsLose, roverlikeGeneralObtainParam.Entries);
			if (isFirst)
			{
				this.PlayObtainTransition(roverlikeGeneralObtainParam.IsLose);
				return;
			}
			this.UiViewSequence.StartSequenceName = (roverlikeGeneralObtainParam.IsLose ? "StartLose" : "StartGet");
		}

		// Token: 0x06040284 RID: 262788 RVA: 0x0107124C File Offset: 0x0106F44C
		private void PlayObtainTransition(bool isLose)
		{
			base.PlayOrReplaySequence(isLose ? "Lose" : "Get", false, null);
		}

		// Token: 0x06040285 RID: 262789 RVA: 0x01071278 File Offset: 0x0106F478
		private void RefreshStyle(bool isLose)
		{
			UUITexture texture = base.GetTexture(6);
			UUIItem uuiitem = texture;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(isLose, fcolor);
			UUISprite sprite = base.GetSprite(7);
			UUIItem uuiitem2 = sprite;
			fcolor = new FColor?(sprite.changeColor);
			uuiitem2.SetChangeColor(isLose, fcolor);
			UUISprite sprite2 = base.GetSprite(8);
			UUIItem uuiitem3 = sprite2;
			fcolor = new FColor?(sprite2.changeColor);
			uuiitem3.SetChangeColor(isLose, fcolor);
			UUISprite sprite3 = base.GetSprite(9);
			UUIItem uuiitem4 = sprite3;
			fcolor = new FColor?(sprite3.changeColor);
			uuiitem4.SetChangeColor(isLose, fcolor);
			UUIText text = base.GetText(1);
			UUIItem uuiitem5 = text;
			fcolor = new FColor?(text.changeColor);
			uuiitem5.SetChangeColor(isLose, fcolor);
		}

		// Token: 0x06040286 RID: 262790 RVA: 0x01071320 File Offset: 0x0106F520
		private void RefreshTitle(bool isLose, List<RoverlikeGainEntry> entries)
		{
			string textStringId = "";
			switch (entries[0].Type)
			{
			case RoverRogueGainDataType.RoverRogueGainBless:
				textStringId = (isLose ? "RoverRogue_HintLoseBlessing" : "RoverRogue_HintGetBlessing");
				break;
			case RoverRogueGainDataType.RoverRogueGainRoleEnhance:
				textStringId = (isLose ? "RoverRogue_HintLoseHint" : "RoverRogue_HintGetHint");
				break;
			case RoverRogueGainDataType.RoverRogueGainItem:
				textStringId = (isLose ? "RoverRogue_HintLoseItem" : "RoverRogue_HintGetItem");
				break;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textStringId, Array.Empty<object>());
		}

		// Token: 0x06040287 RID: 262791 RVA: 0x010713A8 File Offset: 0x0106F5A8
		private void RefreshAnim(bool isLose)
		{
			MultiTemplateComponent multiList = this.MultiList;
			UUIInturnAnimController uuiinturnAnimController = (multiList != null) ? multiList.GetUiAnimController() : null;
			if (uuiinturnAnimController != null)
			{
				uuiinturnAnimController.AnimName = (isLose ? "Start2" : "Start");
				uuiinturnAnimController.PlayFromIndex = 0;
			}
		}

		// Token: 0x06040288 RID: 262792 RVA: 0x010713E7 File Offset: 0x0106F5E7
		private void OnBtnCloseClick()
		{
			this.RefreshObtainList(true);
		}

		// Token: 0x04023FF3 RID: 147443
		[Nullable(2)]
		private MultiTemplateComponent MultiList;

		// Token: 0x04023FF4 RID: 147444
		private readonly List<IMultiTemplateGridData> ScrollDataList = new List<IMultiTemplateGridData>();

		// Token: 0x0200C42D RID: 50221
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403C653 RID: 247379
			public const int BtnClose = 0;

			// Token: 0x0403C654 RID: 247380
			public const int TxtTitle = 1;

			// Token: 0x0403C655 RID: 247381
			public const int Layout = 2;

			// Token: 0x0403C656 RID: 247382
			public const int ItemBlessTemplate = 3;

			// Token: 0x0403C657 RID: 247383
			public const int ItemReinforcementTemplate = 4;

			// Token: 0x0403C658 RID: 247384
			public const int ItemPropTemplate = 5;

			// Token: 0x0403C659 RID: 247385
			public const int TexBg = 6;

			// Token: 0x0403C65A RID: 247386
			public const int SpriteDecoration1 = 7;

			// Token: 0x0403C65B RID: 247387
			public const int SpriteDecoration2 = 8;

			// Token: 0x0403C65C RID: 247388
			public const int SpriteDecoration3 = 9;
		}

		// Token: 0x0200C42E RID: 50222
		[NullableContext(0)]
		private enum ETemplateIndex
		{
			// Token: 0x0403C65E RID: 247390
			Bless,
			// Token: 0x0403C65F RID: 247391
			Prop,
			// Token: 0x0403C660 RID: 247392
			Reinforcement
		}

		// Token: 0x0200C42F RID: 50223
		[NullableContext(0)]
		private enum EObtainSequence
		{
			// Token: 0x0403C662 RID: 247394
			Get,
			// Token: 0x0403C663 RID: 247395
			Lose
		}

		// Token: 0x0200C430 RID: 50224
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private class AttributeGridData : MultiTemplateGridDataBase<IRoverlikeBlessingItemData, RoverlikeBlessingCardItem>
		{
			// Token: 0x0604E9A2 RID: 321954 RVA: 0x015D154E File Offset: 0x015CF74E
			public override int GetTemplateIndex()
			{
				return 0;
			}

			// Token: 0x0604E9A3 RID: 321955 RVA: 0x015D1551 File Offset: 0x015CF751
			public override RoverlikeBlessingCardItem CreateProxy()
			{
				return new RoverlikeBlessingCardItem();
			}
		}

		// Token: 0x0200C431 RID: 50225
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private class PropGridData : MultiTemplateGridDataBase<IRoverlikePropItemData, RoverlikePropCardItem>
		{
			// Token: 0x0604E9A5 RID: 321957 RVA: 0x015D1560 File Offset: 0x015CF760
			public override int GetTemplateIndex()
			{
				return 1;
			}

			// Token: 0x0604E9A6 RID: 321958 RVA: 0x015D1563 File Offset: 0x015CF763
			public override RoverlikePropCardItem CreateProxy()
			{
				return new RoverlikePropCardItem();
			}
		}

		// Token: 0x0200C432 RID: 50226
		[Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private class ReinforcementGridData : MultiTemplateGridDataBase<IRoverlikeReinforcementItemData, RoverlikeReinforcementCardItem>
		{
			// Token: 0x0604E9A8 RID: 321960 RVA: 0x015D1572 File Offset: 0x015CF772
			public override int GetTemplateIndex()
			{
				return 2;
			}

			// Token: 0x0604E9A9 RID: 321961 RVA: 0x015D1575 File Offset: 0x015CF775
			public override RoverlikeReinforcementCardItem CreateProxy()
			{
				return new RoverlikeReinforcementCardItem();
			}
		}
	}
}
