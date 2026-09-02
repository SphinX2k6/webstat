using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.PhoneMessage.View;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FA4 RID: 24484
	[NullableContext(2)]
	[Nullable(0)]
	public class GamepadTopPanel : BattleVisibleChildView
	{
		// Token: 0x0603D859 RID: 251993 RVA: 0x00FA99C0 File Offset: 0x00FA7BC0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 11;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedHomeButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D85A RID: 251994 RVA: 0x00FA9B94 File Offset: 0x00FA7D94
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			base.InitChildType(EBattleUiChild.HomeButton);
			this.AddEvents();
			this.BindRedDot();
			this.UiLevelSequence = new LevelSequencePlayer(this.RootItem);
			this.HomeBtnLevelSequence = new LevelSequencePlayer(base.GetButton(0).RootUIComp);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		}

		// Token: 0x0603D85B RID: 251995 RVA: 0x00FA9BFC File Offset: 0x00FA7DFC
		protected override UniTask InitializeAsync(object param = null)
		{
			GamepadTopPanel.<InitializeAsync>d__8 <InitializeAsync>d__;
			<InitializeAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitializeAsync>d__.<>4__this = this;
			<InitializeAsync>d__.<>1__state = -1;
			<InitializeAsync>d__.<>t__builder.Start<GamepadTopPanel.<InitializeAsync>d__8>(ref <InitializeAsync>d__);
			return <InitializeAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D85C RID: 251996 RVA: 0x00FA9C40 File Offset: 0x00FA7E40
		public override void Reset()
		{
			base.Reset();
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			GamepadPhoneMessageButton phoneMsgButton = this.PhoneMsgButton;
			if (phoneMsgButton != null)
			{
				phoneMsgButton.Destroy(null);
			}
			this.PhoneMsgButton = null;
			this.RemoveEvents();
			this.RemoveRedDot();
		}

		// Token: 0x0603D85D RID: 251997 RVA: 0x00FA9C90 File Offset: 0x00FA7E90
		private void BindRedDot()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				base.GetItem(1).SetUIActive(false);
				return;
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BattleViewMenu, base.GetItem(2), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityEntrance, base.GetItem(3), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			if (ModelBase<FunctionModel>.Instance.IsOpen(10023))
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.AdventureBattleButton, base.GetItem(4), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			}
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BattleViewGachaButton, base.GetItem(5), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BattlePass, base.GetItem(6), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ActivityDirectTrainProEntry, base.GetItem(8), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			if (ModelBase<FunctionModel>.Instance.IsOpen(10130))
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FunctionPhoneMsg, base.GetItem(9), new Action<bool, int>(this.OnLeftRedDotItemRefresh), 0);
			}
		}

		// Token: 0x0603D85E RID: 251998 RVA: 0x00FA9DBC File Offset: 0x00FA7FBC
		private void RemoveRedDot()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return;
			}
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.BattleViewMenu);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.ActivityEntrance);
			if (ModelBase<FunctionModel>.Instance.IsOpen(10023))
			{
				ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.AdventureBattleButton);
			}
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.BattleViewGachaButton);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.BattlePass);
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.ActivityDirectTrainProEntry);
		}

		// Token: 0x0603D85F RID: 251999 RVA: 0x00FA9E30 File Offset: 0x00FA8030
		private void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Add<EFunctionType, bool>(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPhoneTipsClose, new Action(this.OnPhoneTipsClose));
		}

		// Token: 0x0603D860 RID: 252000 RVA: 0x00FA9E94 File Offset: 0x00FA8094
		private void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdate, new Action<EFunctionType, bool>(this.OnFunctionOpenUpdate));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPhoneTipsClose, new Action(this.OnPhoneTipsClose));
		}

		// Token: 0x0603D861 RID: 252001 RVA: 0x00FA9EF8 File Offset: 0x00FA80F8
		protected override void OnShowBattleChildView()
		{
			this.RefreshTipsBg();
			this.RefreshTipsHomeButtonSprite();
			this.OnShowButtons();
			LevelSequencePlayer uiLevelSequence = this.UiLevelSequence;
			if (uiLevelSequence == null)
			{
				return;
			}
			uiLevelSequence.PlayLevelSequenceByName("BtnShow", false, null, false);
		}

		// Token: 0x0603D862 RID: 252002 RVA: 0x00FA9F38 File Offset: 0x00FA8138
		protected override void OnHideBattleChildView()
		{
			this.OnHideButtons();
			LevelSequencePlayer uiLevelSequence = this.UiLevelSequence;
			if (uiLevelSequence == null)
			{
				return;
			}
			uiLevelSequence.PlayLevelSequenceByName("BtnHide", false, null, false);
		}

		// Token: 0x0603D863 RID: 252003 RVA: 0x00FA9F6C File Offset: 0x00FA816C
		private void OnLeftRedDotItemRefresh(bool toState, int _)
		{
			if (!toState)
			{
				return;
			}
			LevelSequencePlayer homeBtnLevelSequence = this.HomeBtnLevelSequence;
			if (homeBtnLevelSequence != null)
			{
				homeBtnLevelSequence.PlayLevelSequenceByName("BtnShow", false, null, false);
			}
			base.GetItem(1).SetUIActive(true);
		}

		// Token: 0x0603D864 RID: 252004 RVA: 0x00FA9FAC File Offset: 0x00FA81AC
		private void RefreshTipsBg()
		{
			bool uiactive = base.GetItem(3).bIsUIActive || base.GetItem(4).bIsUIActive || base.GetItem(5).bIsUIActive || base.GetItem(6).bIsUIActive || base.GetItem(8).bIsUIActive || base.GetItem(9).bIsUIActive;
			base.GetItem(1).SetUIActive(uiactive);
		}

		// Token: 0x0603D865 RID: 252005 RVA: 0x00FAA020 File Offset: 0x00FA8220
		private void RefreshTipsHomeButtonSprite()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(GamepadTopPanel.IconTypeSprite[Singleton<Info>.Instance.InputControllerType]);
			base.SetTextureByPath(resourcePath, base.GetTexture(7), null, null);
		}

		// Token: 0x0603D866 RID: 252006 RVA: 0x00FAA064 File Offset: 0x00FA8264
		private void OnShowButtons()
		{
			bool flag = !ModelBase<PhoneMsgModel>.Instance.IsAllPhoneMsgRead();
			bool flag2 = ModelBase<PhoneMsgModel>.Instance.IsHasUnReceivedMsg() || flag;
			bool flag3 = ControllerBase<GameModeController>.Instance.IsInInstance();
			if (!ModelBase<FunctionModel>.Instance.IsOpen(10130) || !flag2 || flag3)
			{
				base.GetItem(9).SetUIActive(false);
				return;
			}
			GamepadPhoneMessageButton phoneMsgButton = this.PhoneMsgButton;
			if (phoneMsgButton == null)
			{
				return;
			}
			phoneMsgButton.OnShowGamepadTopPanel();
		}

		// Token: 0x0603D867 RID: 252007 RVA: 0x00FAA0CC File Offset: 0x00FA82CC
		private void OnHideButtons()
		{
			if (ModelBase<FunctionModel>.Instance.IsOpen(10130))
			{
				GamepadPhoneMessageButton phoneMsgButton = this.PhoneMsgButton;
				if (phoneMsgButton == null)
				{
					return;
				}
				phoneMsgButton.OnHideGamepadTopPanel();
			}
		}

		// Token: 0x0603D868 RID: 252008 RVA: 0x00FAA0EF File Offset: 0x00FA82EF
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (Singleton<Info>.Instance.IsInGamepad())
			{
				base.SetVisible(5, true);
				this.RefreshTipsHomeButtonSprite();
				return;
			}
			base.SetVisible(5, false);
		}

		// Token: 0x0603D869 RID: 252009 RVA: 0x00FAA114 File Offset: 0x00FA8314
		private void OnFunctionOpenUpdate(EFunctionType functionType, bool isOpen)
		{
			if (functionType == EFunctionType.AdventureGuide && isOpen)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.AdventureBattleButton, base.GetItem(4), null, 0);
			}
			if (functionType == EFunctionType.PhoneMsg && isOpen)
			{
				ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.FunctionPhoneMsg, base.GetItem(9), null, 0);
			}
		}

		// Token: 0x0603D86A RID: 252010 RVA: 0x00FAA164 File Offset: 0x00FA8364
		private void OnClickedHomeButton()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				ControllerBase<InstanceDungeonController>.Instance.OnClickInstanceDungeonExitButton(null, null, true);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.FunctionView, null, null);
		}

		// Token: 0x0603D86B RID: 252011 RVA: 0x00FAA194 File Offset: 0x00FA8394
		private void OnPhoneTipsClose()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopSequenceByKey("Phone", false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("Phone", false, null, false);
		}

		// Token: 0x0603D86C RID: 252012 RVA: 0x00FAA1D9 File Offset: 0x00FA83D9
		[NullableContext(1)]
		[return: Nullable(2)]
		public UUIItem GetPanelItem(string item)
		{
			if (item == "PhoneMsgButton")
			{
				return base.GetItem(9);
			}
			if (!(item == "EntitySequenceButtonRoot"))
			{
				return null;
			}
			return base.GetItem(10);
		}

		// Token: 0x0603D86D RID: 252013 RVA: 0x00FAA20A File Offset: 0x00FA840A
		public IPhoneMessageButtonImplement GetPhoneMsgButton()
		{
			return this.PhoneMsgButton;
		}

		// Token: 0x040228E2 RID: 141538
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Dictionary<EInputControllerType, string> IconTypeSprite = new Dictionary<EInputControllerType, string>
		{
			{
				EInputControllerType.None,
				"T_IconPcBtn_Xbox17_UI"
			},
			{
				EInputControllerType.Keyboard,
				"T_IconPcBtn_Xbox17_UI"
			},
			{
				EInputControllerType.PS4,
				"T_IconPcBtn_PsCai_UI"
			},
			{
				EInputControllerType.PS5,
				"T_IconPcBtn_PsCai_UI"
			},
			{
				EInputControllerType.XboxOne,
				"T_IconPcBtn_Xbox17_UI"
			},
			{
				EInputControllerType.Touch,
				"T_IconPcBtn_Xbox17_UI"
			},
			{
				EInputControllerType.BackBone,
				"T_IconPcBtn_Xbox17_UI"
			},
			{
				EInputControllerType.NsPro,
				"T_IconPcBtn_Xbox17_UI"
			}
		};

		// Token: 0x040228E3 RID: 141539
		private LevelSequencePlayer UiLevelSequence;

		// Token: 0x040228E4 RID: 141540
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x040228E5 RID: 141541
		private LevelSequencePlayer HomeBtnLevelSequence;

		// Token: 0x040228E6 RID: 141542
		private GamepadPhoneMessageButton PhoneMsgButton;

		// Token: 0x0200BFB6 RID: 49078
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B02E RID: 241710
			HomeButton,
			// Token: 0x0403B02F RID: 241711
			TipsBgItem,
			// Token: 0x0403B030 RID: 241712
			HomeButtonRedDotItem,
			// Token: 0x0403B031 RID: 241713
			ActivityRedDotItem,
			// Token: 0x0403B032 RID: 241714
			AdventureRedDotItem,
			// Token: 0x0403B033 RID: 241715
			GachaRedDotItem,
			// Token: 0x0403B034 RID: 241716
			BattlePassRedDotItem,
			// Token: 0x0403B035 RID: 241717
			HomeButtonTexture,
			// Token: 0x0403B036 RID: 241718
			DirectTrainProItem,
			// Token: 0x0403B037 RID: 241719
			PhoneMsgButtonItem,
			// Token: 0x0403B038 RID: 241720
			EntitySequenceButtonRoot
		}
	}
}
