using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RogueBattle
{
	// Token: 0x020051FE RID: 20990
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueBattlePhantomInfoAffix : GridProxyAbstract<PhantomAffixInfo>
	{
		// Token: 0x06035DB0 RID: 220592 RVA: 0x00D8D830 File Offset: 0x00D8BA30
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(1, typeof(UUIItem)),
				new ValueTuple<int, Type>(2, typeof(UUIItem)),
				new ValueTuple<int, Type>(3, typeof(UUIText)),
				new ValueTuple<int, Type>(4, typeof(UUIText))
			};
		}

		// Token: 0x06035DB1 RID: 220593 RVA: 0x00D8D8B8 File Offset: 0x00D8BAB8
		protected override UniTask OnBeforeStartAsync()
		{
			RogueBattlePhantomInfoAffix.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RogueBattlePhantomInfoAffix.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035DB2 RID: 220594 RVA: 0x00D8D8FB File Offset: 0x00D8BAFB
		protected override void OnBeforeShow()
		{
			base.OnBeforeShow();
			Singleton<EventSystem>.Instance.Add(EEventName.RogueBattleSelectOptionPreview, new Action(this.RefreshSelectGainData));
		}

		// Token: 0x06035DB3 RID: 220595 RVA: 0x00D8D91F File Offset: 0x00D8BB1F
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			Singleton<EventSystem>.Instance.Remove(EEventName.RogueBattleSelectOptionPreview, new Action(this.RefreshSelectGainData));
		}

		// Token: 0x06035DB4 RID: 220596 RVA: 0x00D8D943 File Offset: 0x00D8BB43
		private RogueBattleTokenElementWithCount CreateElementItem()
		{
			return new RogueBattleTokenElementWithCount();
		}

		// Token: 0x06035DB5 RID: 220597 RVA: 0x00D8D94C File Offset: 0x00D8BB4C
		public override void Refresh(PhantomAffixInfo data, bool isSelected, int gridIndex)
		{
			RogueBattlePhantomInfoAffix.<>c__DisplayClass9_0 CS$<>8__locals1 = new RogueBattlePhantomInfoAffix.<>c__DisplayClass9_0();
			CS$<>8__locals1.<>4__this = this;
			this.Data = data;
			RogueResAffix? rogueResAffix = ConfigBase<RogueBattleConfig>.Instance.GetRogueResAffix(data.ConfigId);
			if (rogueResAffix == null)
			{
				return;
			}
			if (ModelBase<RogueBattleModel>.Instance.DescMode == EDescModel.SIMPLE)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueResAffix.Value.AffixDescSimple, Array.Empty<object>());
			}
			else
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), rogueResAffix.Value.AffixDesc, rogueResAffix.Value.AffixDescParam());
			}
			CS$<>8__locals1.elementInfo = RogueBattleUtils.ConvertElementUnitsToElementInfo(data.ElementUnits.ToArray<ElementUnit>());
			UiAsyncTask task = new UiAsyncTask("RogueBattlePhantomInfoAffix.Refresh", delegate()
			{
				RogueBattlePhantomInfoAffix.<>c__DisplayClass9_0.<<Refresh>b__0>d <<Refresh>b__0>d;
				<<Refresh>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
				<<Refresh>b__0>d.<>4__this = CS$<>8__locals1;
				<<Refresh>b__0>d.<>1__state = -1;
				<<Refresh>b__0>d.<>t__builder.Start<RogueBattlePhantomInfoAffix.<>c__DisplayClass9_0.<<Refresh>b__0>d>(ref <<Refresh>b__0>d);
				return <<Refresh>b__0>d.<>t__builder.Task;
			}, null);
			base.RunAsyncTask(task);
		}

		// Token: 0x06035DB6 RID: 220598 RVA: 0x00D8DA20 File Offset: 0x00D8BC20
		public void RefreshSelectGainData()
		{
			bool flag = true;
			RogueResGainData selectGainData = ModelBase<RogueBattleModel>.Instance.SelectGainData;
			if (selectGainData == null)
			{
				if (this.UnlockState)
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.PlayLevelSequenceByName("Disappear", false, null, false);
					}
					this.UnlockState = false;
				}
				return;
			}
			Dictionary<int, int> dictionary = new Dictionary<int, int>();
			if (this.Data != null)
			{
				foreach (ElementUnit elementUnit in this.Data.ElementUnits)
				{
					dictionary[elementUnit.ElementId] = elementUnit.Count;
				}
			}
			Dictionary<int, int> dictionary2 = new Dictionary<int, int>();
			foreach (ElementUnit elementUnit2 in selectGainData.RogueResToken.ElementUnits)
			{
				IRogueBattleElementInfo elementInfoById = ModelBase<RogueBattleModel>.Instance.GetElementInfoById(elementUnit2.ElementId);
				int num = (elementInfoById != null) ? elementInfoById.Count : 0;
				dictionary2[elementUnit2.ElementId] = elementUnit2.Count + num;
			}
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				int value = keyValuePair.Value;
				if (!dictionary2.ContainsKey(key) || dictionary2[key] < value)
				{
					flag = false;
				}
			}
			bool flag2 = flag && this.Data != null && !this.Data.Isunlock;
			base.GetItem(2).SetUIActive(flag2);
			UUIText text = base.GetText(3);
			if (text != null)
			{
				UUIItem uuiitem = text;
				bool bUseChangeColor = flag2;
				FColor? fcolor = new FColor?(text.changeColor);
				uuiitem.SetChangeColor(bUseChangeColor, fcolor);
			}
			if (flag2)
			{
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlayLevelSequenceByName("Complete", false, null, false);
				}
				this.UnlockState = true;
				return;
			}
			if (this.UnlockState)
			{
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null)
				{
					levelSequencePlayer3.PlayLevelSequenceByName("Disappear", false, null, false);
				}
				this.UnlockState = false;
			}
		}

		// Token: 0x0401EEC0 RID: 126656
		[Nullable(2)]
		public PhantomAffixInfo Data;

		// Token: 0x0401EEC1 RID: 126657
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public GenericLayout<RogueBattleTokenElementWithCount, IRogueBattleElementInfo> ElementLayout;

		// Token: 0x0401EEC2 RID: 126658
		[Nullable(2)]
		public LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0401EEC3 RID: 126659
		public bool UnlockState;
	}
}
