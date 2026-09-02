using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using UnrealEngine;

// Token: 0x02001D10 RID: 7440
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GameBudgetController : ControllerBase<GameBudgetController>
{
	// Token: 0x0600DA80 RID: 55936 RVA: 0x003AB7C8 File Offset: 0x003A99C8
	protected override bool OnInit()
	{
		this.GameBudgetModes.Add(EGameBudgetMode.Normal, new GameBudgetNormalMode());
		this.GameBudgetModes.Add(EGameBudgetMode.Plot, new GameBudgetPlotMode());
		this.GameBudgetModes.Add(EGameBudgetMode.StreamingSource, new GameBudgetStreamingSourceMode());
		Singleton<EventSystem>.Instance.Add<EntityHandle, EntityHandle>(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleRefreshGameBudgetCenterRole));
		Singleton<EventSystem>.Instance.Add<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnCameraModelChange));
		return base.OnInit();
	}

	// Token: 0x0600DA81 RID: 55937 RVA: 0x003AB848 File Offset: 0x003A9A48
	protected override bool OnClear()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnChangeRole, new Action<EntityHandle, EntityHandle>(this.OnChangeRoleRefreshGameBudgetCenterRole));
		Singleton<EventSystem>.Instance.Remove<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.OnCameraModelChange));
		this.CurrentMode = null;
		this.GameBudgetModes.Clear();
		return base.OnClear();
	}

	// Token: 0x0600DA82 RID: 55938 RVA: 0x003AB8A5 File Offset: 0x003A9AA5
	private void OnChangeRoleRefreshGameBudgetCenterRole(EntityHandle newEntityHandle, [Nullable(2)] EntityHandle oldEntityHandle)
	{
		this.SetCenterRole(Global.BaseCharacter);
	}

	// Token: 0x0600DA83 RID: 55939 RVA: 0x003AB8B2 File Offset: 0x003A9AB2
	private void OnCameraModelChange(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName)
	{
		if (cameraName != "MainCamera")
		{
			return;
		}
		if (newMode == ECustomCameraMode.Sequence && ModelBase<PlotModel>.Instance.IsInPlot)
		{
			this.SetModel(EGameBudgetMode.Plot);
			return;
		}
		this.SetModel(EGameBudgetMode.Normal);
	}

	// Token: 0x0600DA84 RID: 55940 RVA: 0x003AB8E4 File Offset: 0x003A9AE4
	[NullableContext(2)]
	private GameBudgetMode GetMode(EGameBudgetMode modelEnum)
	{
		GameBudgetMode result;
		if (!this.GameBudgetModes.TryGetValue(modelEnum, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.LC;
			string message = "[GameBudget]未初始化模式对象";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ModelEnum", modelEnum);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x0600DA85 RID: 55941 RVA: 0x003AB930 File Offset: 0x003A9B30
	public void OpenStreamingSourceMode()
	{
		GameBudgetMode mode = this.GetMode(EGameBudgetMode.StreamingSource);
		if (mode != null)
		{
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.LC, "[GameBudget]开启流送源模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CurrentMode = mode;
			Singleton<GameBudgetInterfaceController>.Instance.OnBudgetModelChange(mode);
		}
	}

	// Token: 0x0600DA86 RID: 55942 RVA: 0x003AB978 File Offset: 0x003A9B78
	public void CloseStreamingSourceMode()
	{
		GameBudgetMode gameBudgetMode;
		if (this.GameBudgetModes.TryGetValue(EGameBudgetMode.Normal, out gameBudgetMode))
		{
			Singleton<Log>.Instance.Info(ELogModule.Game, ELogAuthor.LC, "[GameBudget]关闭流送源模式, 切回普通模式", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.CurrentMode = gameBudgetMode;
			Singleton<GameBudgetInterfaceController>.Instance.OnBudgetModelChange(gameBudgetMode);
		}
	}

	// Token: 0x0600DA87 RID: 55943 RVA: 0x003AB9C3 File Offset: 0x003A9BC3
	private bool CheckCanSwitchMode()
	{
		return this.CurrentMode == null || this.CurrentMode.AllowSwitchMode();
	}

	// Token: 0x0600DA88 RID: 55944 RVA: 0x003AB9DA File Offset: 0x003A9BDA
	private bool CheckCanSetCenterActor()
	{
		return this.CurrentMode == null || this.CurrentMode.AllowSetCenterActor();
	}

	// Token: 0x0600DA89 RID: 55945 RVA: 0x003AB9F1 File Offset: 0x003A9BF1
	private bool CheckCanSetCenterOffset()
	{
		return this.CurrentMode == null || this.CurrentMode.AllowSetCenterOffset();
	}

	// Token: 0x0600DA8A RID: 55946 RVA: 0x003ABA08 File Offset: 0x003A9C08
	public void SetCenterRole(AActor centerActor)
	{
		if (centerActor == null)
		{
			return;
		}
		if (!this.CheckCanSetCenterActor())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.LC;
			string message = "[GameBudget]当前模式不允许自由设置CenterActor";
			string item = "CurrentMode";
			GameBudgetMode currentMode = this.CurrentMode;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (currentMode != null) ? currentMode.GameBudgetModeName : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		FVectorDouble? offset = null;
		if (centerActor is TsBaseCharacter)
		{
			CreatureModel instance2 = ModelBase<CreatureModel>.Instance;
			WorldEntity worldEntity;
			if (instance2 == null)
			{
				worldEntity = null;
			}
			else
			{
				EntityHandle entityById = instance2.GetEntityById(((TsBaseCharacter)centerActor).EntityId);
				worldEntity = ((entityById != null) ? entityById.Entity : null);
			}
			WorldEntity worldEntity2 = worldEntity;
			if (worldEntity2 != null)
			{
				CharacterMorphComponent component = worldEntity2.GetComponent<CharacterMorphComponent>();
				offset = ((component != null) ? component.GetCenterActorLocationOffset() : null);
			}
		}
		Singleton<GameBudgetInterfaceController>.Instance.OnChangeCenterRole(centerActor, offset);
	}

	// Token: 0x0600DA8B RID: 55947 RVA: 0x003ABAC0 File Offset: 0x003A9CC0
	private void SetModel(EGameBudgetMode newModel)
	{
		if (!this.CheckCanSwitchMode())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.LC;
			string message = "[GameBudget]当前模式不允许自由切换其他模式";
			string item = "CurrentMode";
			GameBudgetMode currentMode = this.CurrentMode;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (currentMode != null) ? currentMode.GameBudgetModeName : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		GameBudgetMode gameBudgetMode;
		if (this.GameBudgetModes.TryGetValue(newModel, out gameBudgetMode))
		{
			Singleton<GameBudgetInterfaceController>.Instance.OnBudgetModelChange(gameBudgetMode);
			this.CurrentMode = gameBudgetMode;
		}
	}

	// Token: 0x0600DA8C RID: 55948 RVA: 0x003ABB30 File Offset: 0x003A9D30
	public void SetCenterOffset(FVectorDouble offset)
	{
		if (!this.CheckCanSetCenterOffset())
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Game;
			ELogAuthor author = ELogAuthor.LC;
			string message = "[GameBudget]当前模式不允许自由设置CenterOffset";
			string item = "CurrentMode";
			GameBudgetMode currentMode = this.CurrentMode;
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>(item, (currentMode != null) ? currentMode.GameBudgetModeName : null);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		Singleton<GameBudgetInterfaceController>.Instance.OnChangeCenterRole(null, new FVectorDouble?(offset));
	}

	// Token: 0x04006868 RID: 26728
	private readonly Dictionary<EGameBudgetMode, GameBudgetMode> GameBudgetModes = new Dictionary<EGameBudgetMode, GameBudgetMode>();

	// Token: 0x04006869 RID: 26729
	[Nullable(2)]
	private GameBudgetMode CurrentMode;
}
