using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Quest;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.SlidingBlocks.View.Mission
{
	// Token: 0x02004F18 RID: 20248
	public class MissionItem : UiPanelBase
	{
		// Token: 0x06034544 RID: 214340 RVA: 0x00D18558 File Offset: 0x00D16758
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnTrackBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06034545 RID: 214341 RVA: 0x00D1874C File Offset: 0x00D1694C
		protected override UniTask OnBeforeStartAsync()
		{
			MissionItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<MissionItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06034546 RID: 214342 RVA: 0x00D1878F File Offset: 0x00D1698F
		protected override void OnAfterShow()
		{
			base.OnAfterShow();
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			}
		}

		// Token: 0x06034547 RID: 214343 RVA: 0x00D187C0 File Offset: 0x00D169C0
		protected override void OnBeforeHide()
		{
			base.OnBeforeHide();
			if (Singleton<EventSystem>.Instance.Has<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange)))
			{
				Singleton<EventSystem>.Instance.Remove<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			}
		}

		// Token: 0x06034548 RID: 214344 RVA: 0x00D1880C File Offset: 0x00D16A0C
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			this.SetShortcutKey();
		}

		// Token: 0x06034549 RID: 214345 RVA: 0x00D18814 File Offset: 0x00D16A14
		protected override void OnBeforeDestroy()
		{
			ControllerBase<InputDistributeController>.Instance.UnBindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603454A RID: 214346 RVA: 0x00D18831 File Offset: 0x00D16A31
		public void OnTick(float delta)
		{
			ParentStepItem missionStep = this.MissionStep;
			if (missionStep == null)
			{
				return;
			}
			missionStep.OnTick(delta);
		}

		// Token: 0x0603454B RID: 214347 RVA: 0x00D18844 File Offset: 0x00D16A44
		private void SetMainTitleText()
		{
			SlidingBlocksGameServerData serverData = ModelBase<SlidingBlocksModel>.Instance.GameData.ServerData;
			UUIText text = base.GetText(8);
			if (text == null)
			{
				return;
			}
			text.ShowTextNew(serverData.MainTitleTextKey ?? "");
		}

		// Token: 0x0603454C RID: 214348 RVA: 0x00D18884 File Offset: 0x00D16A84
		private UniTask SetProgressText()
		{
			MissionItem.<SetProgressText>d__11 <SetProgressText>d__;
			<SetProgressText>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetProgressText>d__.<>4__this = this;
			<SetProgressText>d__.<>1__state = -1;
			<SetProgressText>d__.<>t__builder.Start<MissionItem.<SetProgressText>d__11>(ref <SetProgressText>d__);
			return <SetProgressText>d__.<>t__builder.Task;
		}

		// Token: 0x0603454D RID: 214349 RVA: 0x00D188C8 File Offset: 0x00D16AC8
		private void SetShortcutKey()
		{
			UUIItem item = base.GetItem(11);
			UUIText text = base.GetText(2);
			UUISprite sprite = base.GetSprite(10);
			if (ModelBase<SlidingBlocksModel>.Instance.GameData.PlayMode != ETetrisPlayMode.MainLine)
			{
				text.SetUIActive(false);
				item.SetUIActive(false);
				sprite.SetUIActive(false);
				return;
			}
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("ChallengeAgain");
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				InputActionBinding actionBinding = Singleton<InputSettingsManager>.Instance.GetActionBinding("玩法放弃");
				if (actionBinding == null)
				{
					item.SetUIActive(false);
					return;
				}
				InputKey pcKey = actionBinding.GetPcKey();
				if (pcKey == null)
				{
					item.SetUIActive(false);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.SlidingBlocks;
					ELogAuthor author = ELogAuthor.YSQ;
					string message = "pcKey为空";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("actionMapping", "玩法放弃");
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				string newText = "<texture=" + pcKey.GetKeyIconPath() + "/>" + textById;
				text.SetText(newText, true);
			}
			else if (Singleton<Info>.Instance.IsInGamepad())
			{
				string newText2 = this.GetGamepadShortcutString("玩法放弃", textById) ?? textById;
				text.SetText(newText2, true);
			}
			else
			{
				string newText3 = ConfigBase<TextConfig>.Instance.GetTextById("ChallengeAgain_mobile") ?? textById;
				text.SetText(newText3, true);
			}
			text.SetAlpha(1f);
			text.SetUIActive(true);
			item.SetUIActive(true);
			sprite.SetUIActive(Singleton<Info>.Instance.InputControllerMainType == EInputControllerMainType.Touch);
			ControllerBase<InputDistributeController>.Instance.UnBindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
			ControllerBase<InputDistributeController>.Instance.BindAction("玩法放弃", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputAction));
		}

		// Token: 0x0603454E RID: 214350 RVA: 0x00D18A68 File Offset: 0x00D16C68
		[NullableContext(1)]
		[return: Nullable(2)]
		private string GetGamepadShortcutString(string actionName, string sourceString)
		{
			InputCombinationActionBinding combinationActionBindingByActionName = Singleton<InputSettingsManager>.Instance.GetCombinationActionBindingByActionName(actionName);
			if (combinationActionBindingByActionName == null)
			{
				return null;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			combinationActionBindingByActionName.GetCurrentPlatformKeyNameMap(dictionary);
			if (dictionary.Count == 0)
			{
				return null;
			}
			string value = actionName;
			string value2 = actionName;
			using (Dictionary<string, string>.Enumerator enumerator = dictionary.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					KeyValuePair<string, string> keyValuePair = enumerator.Current;
					string text;
					string text2;
					keyValuePair.Deconstruct(out text, out text2);
					string key = text;
					string key2 = text2;
					InputKey key3 = Singleton<InputSettings>.Instance.GetKey(key);
					InputKey key4 = Singleton<InputSettings>.Instance.GetKey(key2);
					if (key3 != null)
					{
						value = key3.GetKeyIconPath();
					}
					if (key4 != null)
					{
						value2 = key4.GetKeyIconPath();
					}
				}
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 3);
			defaultInterpolatedStringHandler.AppendLiteral("<texture=");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("/>+<texture=");
			defaultInterpolatedStringHandler.AppendFormatted(value2);
			defaultInterpolatedStringHandler.AppendLiteral("/>");
			defaultInterpolatedStringHandler.AppendFormatted(sourceString);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0603454F RID: 214351 RVA: 0x00D18B74 File Offset: 0x00D16D74
		private void OnTrackBtnClick()
		{
			if (this.IsRequesting)
			{
				return;
			}
			InstanceDungeonInfo instanceDungeonInfo = ModelBase<InstanceDungeonModel>.Instance.GetInstanceDungeonInfo();
			if (instanceDungeonInfo == null)
			{
				return;
			}
			BaseBehaviorTree tree = instanceDungeonInfo.Tree;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.PlayEnd);
			confirmBoxDataNew.SetCloseFunction(delegate
			{
				if (tree.ContainTag(EBehaviorTreeTag.RollbackWaiting))
				{
					Singleton<EventSystem>.Instance.EmitWithTarget(tree.GetBlackBoard(), EEventName.GeneralLogicTreeRollbackWaitingUpdate);
				}
			});
			confirmBoxDataNew.FunctionMap[1] = null;
			Action<bool> <>9__2;
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				if (tree.ContainTag(EBehaviorTreeTag.RollbackWaiting))
				{
					return;
				}
				this.IsRequesting = true;
				GeneralLogicTreeController instance = ControllerBase<GeneralLogicTreeController>.Instance;
				long treeIncId = tree.TreeIncId;
				Action<bool> callback;
				if ((callback = <>9__2) == null)
				{
					callback = (<>9__2 = delegate(bool _)
					{
						this.IsRequesting = false;
					});
				}
				instance.RequestGiveUp(treeIncId, callback);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x06034550 RID: 214352 RVA: 0x00D18BFD File Offset: 0x00D16DFD
		[NullableContext(1)]
		private void OnInputAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (actionType != InputDistributeDefine.EActionType.Release)
			{
				return;
			}
			this.OnTrackBtnClick();
		}

		// Token: 0x0401E2F0 RID: 123632
		[Nullable(2)]
		private ParentStepItem MissionStep;

		// Token: 0x0401E2F1 RID: 123633
		private bool IsRequesting;

		// Token: 0x0200AF5A RID: 44890
		private enum EViewComponent
		{
			// Token: 0x040366AC RID: 222892
			Icon,
			// Token: 0x040366AD RID: 222893
			ParentItem,
			// Token: 0x040366AE RID: 222894
			ShortcutKeyText,
			// Token: 0x040366AF RID: 222895
			BtnTrack,
			// Token: 0x040366B0 RID: 222896
			CompleteItem,
			// Token: 0x040366B1 RID: 222897
			ProcessItem,
			// Token: 0x040366B2 RID: 222898
			CompleteText,
			// Token: 0x040366B3 RID: 222899
			Niagara,
			// Token: 0x040366B4 RID: 222900
			TitleText,
			// Token: 0x040366B5 RID: 222901
			TitleItem,
			// Token: 0x040366B6 RID: 222902
			ShortcutSprite,
			// Token: 0x040366B7 RID: 222903
			ShortcutNode
		}
	}
}
