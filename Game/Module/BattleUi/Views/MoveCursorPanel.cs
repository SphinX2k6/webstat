using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Input.Enum;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Input;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FAD RID: 24493
	public class MoveCursorPanel : BattleVisibleChildView, IExtraShowCursor, IBattleUiCenterPanelOtherMovePanel
	{
		// Token: 0x0603D8AE RID: 252078 RVA: 0x00FAAF83 File Offset: 0x00FA9183
		[NullableContext(1)]
		public void CreateDynamic(UUIItem parentItem)
		{
			this.TagIdVisible = ModelBase<BattleUiModel>.Instance.GetTagIdMoveCursorVisible();
			base.CreateThenShowByResourceIdAsync("UiItem_SlashTip", parentItem, false).Forget();
		}

		// Token: 0x0603D8AF RID: 252079 RVA: 0x00FAAFA8 File Offset: 0x00FA91A8
		[NullableContext(2)]
		public override void Initialize(object param = null)
		{
			IReadOnlyList<float> floatArrayConfig = ConfigCommonParamById.GetFloatArrayConfig("GuyingxiongkaiSafeArea");
			if (floatArrayConfig != null && floatArrayConfig.Count >= 2)
			{
				this.MouseSafeAreaX = floatArrayConfig[0];
				this.MouseSafeAreaY = floatArrayConfig[1];
			}
		}

		// Token: 0x0603D8B0 RID: 252080 RVA: 0x00FAAFE6 File Offset: 0x00FA91E6
		protected override void OnStart()
		{
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.TxtBtn = base.GetTexture(1);
		}

		// Token: 0x0603D8B1 RID: 252081 RVA: 0x00FAB008 File Offset: 0x00FA9208
		protected unsafe override void OnRegisterComponent()
		{
			int num = 1;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int index = 0;
			*span[index] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D8B2 RID: 252082 RVA: 0x00FAB050 File Offset: 0x00FA9250
		protected override void OnAfterShow()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.PlaySequencePurely("Start", false, false, null, null, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 != null)
			{
				levelSequencePlayer2.PlaySequencePurely("Loop", false, false, null, null, false);
			}
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null)
			{
				if (this.TagIdVisible != null)
				{
					this.GameplayTagComp = curRoleData.GameplayTagComponent;
					if (this.GameplayTagComp != null)
					{
						if (this.GameplayTagComp.HasAnyTag(this.TagIdVisible))
						{
							this.NeedCursor = false;
							base.SetUiActive(false);
							curRoleData.MorphShowSpecialEnergyBar = true;
						}
						else
						{
							this.SetTexBtnIcon();
							curRoleData.MorphShowSpecialEnergyBar = false;
							InputDistributeController instance = ControllerBase<InputDistributeController>.Instance;
							IReadOnlyList<string> actionNames = new <>z__ReadOnlyArray<string>(new string[]
							{
								"攻击",
								"闪避"
							});
							TInputHandle<InputDistributeDefine.EActionType> actionCallback;
							if ((actionCallback = MoveCursorPanel.<>O.<0>__InputAction) == null)
							{
								actionCallback = (MoveCursorPanel.<>O.<0>__InputAction = new TInputHandle<InputDistributeDefine.EActionType>(MoveCursorPanel.InputAction));
							}
							instance.BindActions(actionNames, actionCallback);
							Singleton<InputExtraShowCursorCenter>.Instance.RegisterExtraRefreshData("MoveCursorPanel", this);
							foreach (int tagId in this.TagIdVisible)
							{
								BaseTagComponent gameplayTagComp = this.GameplayTagComp;
								if (gameplayTagComp != null)
								{
									gameplayTagComp.AddTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnTagAddOrRemove), null);
								}
							}
						}
					}
					else
					{
						Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnAfterShow this.GameplayTagComp 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
					}
				}
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnAfterShow roleData 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		}

		// Token: 0x0603D8B3 RID: 252083 RVA: 0x00FAB1F4 File Offset: 0x00FA93F4
		private void OnTagAddOrRemove(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
				if (curRoleData != null)
				{
					curRoleData.MorphShowSpecialEnergyBar = true;
				}
				else
				{
					Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnTagAddOrRemove roleData 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
				}
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.BattleUiEnergyBarVisible, true);
				this.NeedCursor = false;
				base.SetUiActive(false);
				InputDistributeController instance = ControllerBase<InputDistributeController>.Instance;
				IReadOnlyList<string> actionNames = new <>z__ReadOnlyArray<string>(new string[]
				{
					"攻击",
					"闪避"
				});
				TInputHandle<InputDistributeDefine.EActionType> actionCallback;
				if ((actionCallback = MoveCursorPanel.<>O.<0>__InputAction) == null)
				{
					actionCallback = (MoveCursorPanel.<>O.<0>__InputAction = new TInputHandle<InputDistributeDefine.EActionType>(MoveCursorPanel.InputAction));
				}
				instance.UnBindActions(actionNames, actionCallback);
				Singleton<InputExtraShowCursorCenter>.Instance.UnRegisterExtraRefreshData("MoveCursorPanel");
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
			}
		}

		// Token: 0x0603D8B4 RID: 252084 RVA: 0x00FAB2B8 File Offset: 0x00FA94B8
		private void InputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (this.TagIdVisible != null)
			{
				BaseTagComponent gameplayTagComp = this.GameplayTagComp;
				if (gameplayTagComp != null && gameplayTagComp.HasAnyTag(this.TagIdVisible))
				{
					return;
				}
			}
			this.SetTexBtnIcon();
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				this.NeedCursor = true;
				InputDistributeController instance = ControllerBase<InputDistributeController>.Instance;
				IReadOnlyList<string> actionNames = new <>z__ReadOnlyArray<string>(new string[]
				{
					"攻击",
					"闪避"
				});
				TInputHandle<InputDistributeDefine.EActionType> actionCallback;
				if ((actionCallback = MoveCursorPanel.<>O.<0>__InputAction) == null)
				{
					actionCallback = (MoveCursorPanel.<>O.<0>__InputAction = new TInputHandle<InputDistributeDefine.EActionType>(MoveCursorPanel.InputAction));
				}
				instance.BindActions(actionNames, actionCallback);
				Singleton<InputExtraShowCursorCenter>.Instance.RegisterExtraRefreshData("MoveCursorPanel", this);
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
				return;
			}
			this.NeedCursor = false;
			InputDistributeController instance2 = ControllerBase<InputDistributeController>.Instance;
			IReadOnlyList<string> actionNames2 = new <>z__ReadOnlyArray<string>(new string[]
			{
				"攻击",
				"闪避"
			});
			TInputHandle<InputDistributeDefine.EActionType> actionCallback2;
			if ((actionCallback2 = MoveCursorPanel.<>O.<0>__InputAction) == null)
			{
				actionCallback2 = (MoveCursorPanel.<>O.<0>__InputAction = new TInputHandle<InputDistributeDefine.EActionType>(MoveCursorPanel.InputAction));
			}
			instance2.UnBindActions(actionNames2, actionCallback2);
			Singleton<InputExtraShowCursorCenter>.Instance.UnRegisterExtraRefreshData("MoveCursorPanel");
			Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
		}

		// Token: 0x0603D8B5 RID: 252085 RVA: 0x00FAB3C8 File Offset: 0x00FA95C8
		private void SetTexBtnIcon()
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/UiIconPcBtn/T_IconPcBtn_Mouse2_UI.T_IconPcBtn_Mouse2_UI", this.TxtBtn, null, null);
				return;
			}
			base.SetTextureByPath("/Game/Aki/UI/UIResources/Common/Image/UiIconPcBtn/T_IconPcBtn_XboxL2_UI.T_IconPcBtn_XboxL2_UI", this.TxtBtn, null, null);
		}

		// Token: 0x0603D8B6 RID: 252086 RVA: 0x00FAB418 File Offset: 0x00FA9618
		protected override void OnHideBattleChildView()
		{
			if (this.NeedCursor)
			{
				InputDistributeController instance = ControllerBase<InputDistributeController>.Instance;
				IReadOnlyList<string> actionNames = new <>z__ReadOnlyArray<string>(new string[]
				{
					"攻击",
					"闪避"
				});
				TInputHandle<InputDistributeDefine.EActionType> actionCallback;
				if ((actionCallback = MoveCursorPanel.<>O.<0>__InputAction) == null)
				{
					actionCallback = (MoveCursorPanel.<>O.<0>__InputAction = new TInputHandle<InputDistributeDefine.EActionType>(MoveCursorPanel.InputAction));
				}
				instance.UnBindActions(actionNames, actionCallback);
				Singleton<InputExtraShowCursorCenter>.Instance.UnRegisterExtraRefreshData("MoveCursorPanel");
				Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
			}
			BattleUiRoleData curRoleData = ModelBase<BattleUiModel>.Instance.GetCurRoleData();
			if (curRoleData != null)
			{
				if (this.TagIdVisible != null && curRoleData.GameplayTagComponent != null)
				{
					foreach (int tagId in this.TagIdVisible)
					{
						curRoleData.GameplayTagComponent.RemoveTagAddOrRemoveListener(tagId, new BaseTagComponent.TTagSwitchedCallback(this.OnTagAddOrRemove));
					}
				}
				curRoleData.MorphShowSpecialEnergyBar = true;
			}
			else
			{
				Singleton<Log>.Instance.Error(ELogModule.Battle, ELogAuthor.HCW, "OnBeforeDestroy roleData 为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
			}
		}

		// Token: 0x0603D8B7 RID: 252087 RVA: 0x00FAB53A File Offset: 0x00FA973A
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
		}

		// Token: 0x0603D8B8 RID: 252088 RVA: 0x00FAB554 File Offset: 0x00FA9754
		[NullableContext(1)]
		private static void InputAction(string name, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if ("攻击" == name && actionType == InputDistributeDefine.EActionType.Press)
			{
				ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.攻击, EInputState.Press);
				return;
			}
			if ("闪避" == name && actionType == InputDistributeDefine.EActionType.Press)
			{
				ControllerBase<InputController>.Instance.InputAction(CSharpScript.Game.Input.EInputAction.闪避, EInputState.Press);
			}
		}

		// Token: 0x0603D8B9 RID: 252089 RVA: 0x00FAB5A2 File Offset: 0x00FA97A2
		public bool IsShowCursor()
		{
			return Singleton<Info>.Instance.IsInKeyBoard() && this.NeedCursor;
		}

		// Token: 0x0603D8BA RID: 252090 RVA: 0x00FAB5B8 File Offset: 0x00FA97B8
		public void Tick(float delta)
		{
			if (!this.IsShowCursor())
			{
				return;
			}
			Vector2D cursorPosition = Global.CharacterController.GetCursorPosition();
			if (cursorPosition == null)
			{
				return;
			}
			Vector2D viewportSize = ModelBase<BattleUiModel>.Instance.ViewportSize;
			double num = viewportSize.X * 0.5;
			double num2 = viewportSize.Y * 0.5;
			double num3 = num * (double)this.MouseSafeAreaX;
			double num4 = num2 * (double)this.MouseSafeAreaY;
			double num5 = cursorPosition.X - num;
			double num6 = num2 - cursorPosition.Y;
			if (Math.Abs(num5) < num3 && Math.Abs(num6) < num4)
			{
				return;
			}
			float num7 = (float)(Math.Atan2(num6, num5) * 57.295780181884766);
			if (num7 < 0f)
			{
				num7 += 360f;
			}
			MoveCursorPanel.ESectorScreen esectorScreen = (MoveCursorPanel.ESectorScreen)Math.Floor((double)((num7 + 22.5f) * 0.022222223f)) % (MoveCursorPanel.ESectorScreen)8;
			if (esectorScreen == this.LastSector)
			{
				return;
			}
			this.LastSector = esectorScreen;
			switch (esectorScreen)
			{
			case MoveCursorPanel.ESectorScreen.Right:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.UpRight:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.Up:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.UpLeft:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, -1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, 1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.Left:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, -1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.DowLeft:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, -1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, -1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.Down:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, -1f, true);
				return;
			case MoveCursorPanel.ESectorScreen.DownRight:
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveRight, 1f, true);
				ControllerBase<InputController>.Instance.InputAxis(EInputAxis.MoveForward, -1f, true);
				return;
			default:
				return;
			}
		}

		// Token: 0x040228F2 RID: 141554
		private const float SECTOR_ANGLE_SIZE = 0.022222223f;

		// Token: 0x040228F3 RID: 141555
		private const float HALF_SECTOR_ANGLE_SIZE = 22.5f;

		// Token: 0x040228F4 RID: 141556
		private const int SECTOR_NUM = 8;

		// Token: 0x040228F5 RID: 141557
		[Nullable(1)]
		private const string MOUSE_SAFE_AREA_KEY = "GuyingxiongkaiSafeArea";

		// Token: 0x040228F6 RID: 141558
		[Nullable(1)]
		private const string THIS_VIEW_NAME = "MoveCursorPanel";

		// Token: 0x040228F7 RID: 141559
		private float MouseSafeAreaX;

		// Token: 0x040228F8 RID: 141560
		private float MouseSafeAreaY;

		// Token: 0x040228F9 RID: 141561
		private MoveCursorPanel.ESectorScreen LastSector;

		// Token: 0x040228FA RID: 141562
		private bool NeedCursor = true;

		// Token: 0x040228FB RID: 141563
		[Nullable(2)]
		private int[] TagIdVisible;

		// Token: 0x040228FC RID: 141564
		[Nullable(2)]
		private UUITexture TxtBtn;

		// Token: 0x040228FD RID: 141565
		[Nullable(2)]
		private BaseTagComponent GameplayTagComp;

		// Token: 0x040228FE RID: 141566
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BFC9 RID: 49097
		private enum EChildType
		{
			// Token: 0x0403B08F RID: 241807
			TexBtn = 1
		}

		// Token: 0x0200BFCA RID: 49098
		private enum ESectorScreen
		{
			// Token: 0x0403B091 RID: 241809
			Right,
			// Token: 0x0403B092 RID: 241810
			UpRight,
			// Token: 0x0403B093 RID: 241811
			Up,
			// Token: 0x0403B094 RID: 241812
			UpLeft,
			// Token: 0x0403B095 RID: 241813
			Left,
			// Token: 0x0403B096 RID: 241814
			DowLeft,
			// Token: 0x0403B097 RID: 241815
			Down,
			// Token: 0x0403B098 RID: 241816
			DownRight
		}

		// Token: 0x0200BFCB RID: 49099
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403B099 RID: 241817
			public static TInputHandle<InputDistributeDefine.EActionType> <0>__InputAction;
		}
	}
}
