using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Render.RuntimeBP.Battle;
using AkiClient.Game.Aki.Render.RuntimeBP.RenderData;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Module.Teleport;
using CSharpScript.Game.Render.DebugDraw;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004780 RID: 18304
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RenderModuleModel : ModelBase<RenderModuleModel>
	{
		// Token: 0x0602F79A RID: 194458 RVA: 0x00B48E81 File Offset: 0x00B47081
		public EWuYinQuState GetCurrentKeyState(string actorKey)
		{
			if (actorKey == this.CurrentBattleKey)
			{
				return this.CurrentBattleState;
			}
			return EWuYinQuState.StateIdle;
		}

		// Token: 0x0602F79B RID: 194459 RVA: 0x00B48E99 File Offset: 0x00B47099
		public bool GetIdleClearAtmosphere(string actorKey)
		{
			return actorKey == this.CurrentBattleKey && this.IsIdleClearAtmosphere;
		}

		// Token: 0x0602F79C RID: 194460 RVA: 0x00B48EB4 File Offset: 0x00B470B4
		public unsafe void SetBattleState(string key, EWuYinQuState state, bool instantTransition = false)
		{
			this.CurrentBattleKey = key;
			this.CurrentBattleState = state;
			this.CurrentInputBattleState = state;
			if (this.CurrentBattleState == EWuYinQuState.Nothing)
			{
				this.IsIdleClearAtmosphere = true;
				this.CurrentBattleState = EWuYinQuState.StateIdle;
			}
			else
			{
				this.IsIdleClearAtmosphere = false;
			}
			this.InstantTransition = instantTransition;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderBattle;
			ELogAuthor author = ELogAuthor.HCS;
			string message = "BOSS战设置战斗状态Inner";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("key", key);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("state", state);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0602F79D RID: 194461 RVA: 0x00B48F55 File Offset: 0x00B47155
		public bool IsStateInstantTransition()
		{
			return this.InstantTransition;
		}

		// Token: 0x0602F79E RID: 194462 RVA: 0x00B48F60 File Offset: 0x00B47160
		private string GetStateString(EWuYinQuState inputState)
		{
			string result;
			switch (inputState)
			{
			case EWuYinQuState.StateIdle:
				result = "静止状态";
				break;
			case EWuYinQuState.StateFighting1:
				result = "战斗1阶段";
				break;
			case EWuYinQuState.StateFighting2:
				result = "战斗2阶段";
				break;
			case EWuYinQuState.StateFighting3:
				result = "战斗3阶段";
				break;
			case EWuYinQuState.Nothing:
				result = "无状态";
				break;
			default:
				result = "错误";
				break;
			}
			return result;
		}

		// Token: 0x0602F79F RID: 194463 RVA: 0x00B48FB8 File Offset: 0x00B471B8
		public TArray<string> GetWuYinQuBattleDebugInfo()
		{
			TArray<string> tarray = new TArray<string>();
			List<string> list = new List<string>();
			list.Add(this.GetCurrentBattleKey() + "," + this.GetStateString(this.CurrentInputBattleState));
			foreach (WuYinQuBattleActor wuYinQuBattleActor in this.AllWuYinQuBattleActors.Values)
			{
				if (UKismetSystemLibrary.IsValid(wuYinQuBattleActor))
				{
					string item = wuYinQuBattleActor.GetKey() + "," + this.GetStateString(wuYinQuBattleActor.GetCurrentBattleState());
					list.Add(item);
				}
			}
			WorldGlobal.ToUeStringArray(list, tarray);
			return tarray;
		}

		// Token: 0x0602F7A0 RID: 194464 RVA: 0x00B49070 File Offset: 0x00B47270
		public EWuYinQuState GetBattleState(string key)
		{
			if (this.CurrentBattleKey == key)
			{
				return this.CurrentBattleState;
			}
			return EWuYinQuState.StateIdle;
		}

		// Token: 0x0602F7A1 RID: 194465 RVA: 0x00B49088 File Offset: 0x00B47288
		[NullableContext(2)]
		public string GetCurrentBattleKey()
		{
			return this.CurrentBattleKey;
		}

		// Token: 0x0602F7A2 RID: 194466 RVA: 0x00B49090 File Offset: 0x00B47290
		public void AddBattleReference(FVectorDouble location)
		{
			this.BattleRefCount++;
			if (this.BattleRefCount > 0)
			{
				this.SetStreamingSourceState(location, true);
			}
		}

		// Token: 0x0602F7A3 RID: 194467 RVA: 0x00B490B1 File Offset: 0x00B472B1
		public float GetSnowIntensity()
		{
			RenderDataManager instance = Singleton<RenderDataManager>.Instance;
			if (instance == null)
			{
				return 0f;
			}
			return instance.GetSnowIntensity();
		}

		// Token: 0x0602F7A4 RID: 194468 RVA: 0x00B490C7 File Offset: 0x00B472C7
		public float GetRainIntensity()
		{
			RenderDataManager instance = Singleton<RenderDataManager>.Instance;
			if (instance == null)
			{
				return 0f;
			}
			return instance.GetRainIntensity();
		}

		// Token: 0x0602F7A5 RID: 194469 RVA: 0x00B490DD File Offset: 0x00B472DD
		public void DecBattleReference()
		{
			this.BattleRefCount--;
			if (this.BattleRefCount <= 0)
			{
				this.SetStreamingSourceState(new FVectorDouble(0.0, 0.0, 0.0), false);
			}
		}

		// Token: 0x0602F7A6 RID: 194470 RVA: 0x00B4911D File Offset: 0x00B4731D
		public void SetStreamingSourceState(FVectorDouble location, bool isEnable)
		{
		}

		// Token: 0x0602F7A7 RID: 194471 RVA: 0x00B49120 File Offset: 0x00B47320
		[return: Nullable(2)]
		public WuYinQuBattleActor GetWuYinQuBattleActorByName(string name)
		{
			WuYinQuBattleActor result;
			if (this.AllWuYinQuBattleActors.TryGetValue(name, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0602F7A8 RID: 194472 RVA: 0x00B49140 File Offset: 0x00B47340
		public bool AddWuYinQuBattleActor(WuYinQuBattleActor actor)
		{
			if (!UKismetSystemLibrary.IsValid(actor))
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.HCS, "无音区actor添加失败1", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			string key = actor.GetKey();
			if (actor.IsInitialize())
			{
				return false;
			}
			if (this.GetWuYinQuBattleActorByName(key) != null)
			{
				return false;
			}
			if (actor.Init())
			{
				this.AllWuYinQuBattleActors[key] = actor;
				return true;
			}
			return false;
		}

		// Token: 0x0602F7A9 RID: 194473 RVA: 0x00B491A8 File Offset: 0x00B473A8
		public bool RemoveWuYinQuBattleActor(WuYinQuBattleActor actor)
		{
			if (!UKismetSystemLibrary.IsValid(actor))
			{
				Singleton<Log>.Instance.Error(ELogModule.RenderBattle, ELogAuthor.HCS, "无音区actor移除失败1", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			string key = actor.GetKey();
			return this.AllWuYinQuBattleActors.Remove(key);
		}

		// Token: 0x0602F7AA RID: 194474 RVA: 0x00B491F3 File Offset: 0x00B473F3
		public void AddTickableObject(IRenderModuleTickableObject obj)
		{
			if (this.TickableObjects.IndexOf(obj) < 0)
			{
				this.TickableObjects.Add(obj);
			}
		}

		// Token: 0x0602F7AB RID: 194475 RVA: 0x00B49210 File Offset: 0x00B47410
		public void RemoveTickableObject(IRenderModuleTickableObject obj)
		{
			int num = this.TickableObjects.IndexOf(obj);
			if (num < 0)
			{
				return;
			}
			if (this.TickableObjects.Count <= 2)
			{
				this.TickableObjects.RemoveAt(num);
				return;
			}
			List<IRenderModuleTickableObject> tickableObjects = this.TickableObjects;
			int index = num;
			List<IRenderModuleTickableObject> tickableObjects2 = this.TickableObjects;
			tickableObjects[index] = tickableObjects2[tickableObjects2.Count - 1];
			this.TickableObjects.RemoveAt(this.TickableObjects.Count - 1);
		}

		// Token: 0x0602F7AC RID: 194476 RVA: 0x00B49284 File Offset: 0x00B47484
		public void AddCharRenderShell(CharRenderingComponent charRenderingComponent)
		{
			CharRenderShell charRenderShell = new CharRenderShell();
			charRenderShell.Init(charRenderingComponent);
			this.AllRenderShell[charRenderingComponent] = charRenderShell;
		}

		// Token: 0x0602F7AD RID: 194477 RVA: 0x00B492AB File Offset: 0x00B474AB
		public bool RemoveCharRenderShell(CharRenderingComponent charRenderingComponent)
		{
			CharRenderShell valueOrDefault = this.AllRenderShell.GetValueOrDefault(charRenderingComponent);
			if (valueOrDefault != null)
			{
				valueOrDefault.Clear();
			}
			return this.AllRenderShell.Remove(charRenderingComponent);
		}

		// Token: 0x170081AB RID: 33195
		// (get) Token: 0x0602F7AE RID: 194478 RVA: 0x00B492D0 File Offset: 0x00B474D0
		public bool ForceTickCharRenderShell
		{
			get
			{
				return this.ForceTickCharRenderShellInternal;
			}
		}

		// Token: 0x0602F7AF RID: 194479 RVA: 0x00B492D8 File Offset: 0x00B474D8
		private void OnSetGamePaused(bool isPaused)
		{
			if (!isPaused && this.ForceTickCharRenderShellInternal)
			{
				Singleton<Log>.Instance.Warn(ELogModule.Render, ELogAuthor.WLJ, "退出真时停时仍然开启CharRenderShell的强制Tick", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.DisableForceTickCharRenderShell("RenderModuleModel OnSetGamePaused");
			}
		}

		// Token: 0x0602F7B0 RID: 194480 RVA: 0x00B49317 File Offset: 0x00B47517
		private void OnWorldDone()
		{
			RenderDataManager instance = Singleton<RenderDataManager>.Instance;
			PlayerInfoModel instance2 = ModelBase<PlayerInfoModel>.Instance;
			instance.SetIsPlayerMale(instance2 != null && instance2.GetPlayerGender() == EPlayerGender.Male);
		}

		// Token: 0x0602F7B1 RID: 194481 RVA: 0x00B49337 File Offset: 0x00B47537
		private void OnBattleStateChanged(bool inBattle)
		{
			UKuroRenderingRuntimeBPPluginBPLibrary.SetCharacterInBattle(GlobalData.World, inBattle);
		}

		// Token: 0x0602F7B2 RID: 194482 RVA: 0x00B49344 File Offset: 0x00B47544
		public void DisableForceTickCharRenderShell(string reason)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Render;
			ELogAuthor author = ELogAuthor.WLJ;
			string message = "关闭CharRenderShell的强制Tick";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.ForceTickCharRenderShellInternal = false;
		}

		// Token: 0x0602F7B3 RID: 194483 RVA: 0x00B49380 File Offset: 0x00B47580
		public void EnableForceTickCharRenderShell(string reason)
		{
			if (!Singleton<TickSystem>.Instance.IsPaused)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Render;
				ELogAuthor author = ELogAuthor.WLJ;
				string message = "只有真时停环境下才能开启CharRenderShell的强制Tick";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Reason", reason);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Render;
			ELogAuthor author2 = ELogAuthor.WLJ;
			string message2 = "开启CharRenderShell的强制Tick";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Reason", reason);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			this.ForceTickCharRenderShellInternal = true;
		}

		// Token: 0x0602F7B4 RID: 194484 RVA: 0x00B493F0 File Offset: 0x00B475F0
		public unsafe void Tick(float delta)
		{
			float num = 0.001f;
			float num2 = delta * num;
			foreach (IRenderModuleTickableObject renderModuleTickableObject in this.TickableObjects)
			{
				try
				{
					renderModuleTickableObject.Tick(num2);
				}
				catch (Exception ex)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Render;
					ELogAuthor author = ELogAuthor.LSY;
					string message = "TickableObject Tick执行异常";
					Exception error = ex;
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
			}
			if (!CharRenderShell.CharRenderShellGameBudgetOptimize || Singleton<Info>.Instance.IsInEditorTick() || this.ForceTickCharRenderShellInternal)
			{
				using (Dictionary<CharRenderingComponent, CharRenderShell>.ValueCollection.Enumerator enumerator2 = this.AllRenderShell.Values.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						CharRenderShell charRenderShell = enumerator2.Current;
						try
						{
							charRenderShell.Tick((double)num2, false);
						}
						catch (Exception ex2)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.Render;
							ELogAuthor author2 = ELogAuthor.LSY;
							string message2 = "RenderShell Tick执行异常";
							Exception error2 = ex2;
							ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("error", ex2.Message);
							instance2.ErrorWithStack(module2, author2, message2, error2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
						}
					}
					goto IL_1CB;
				}
			}
			bool flag;
			if (Singleton<Info>.Instance.IsGameRunning())
			{
				if (!GlobalData.IsUiSceneOpen && !GlobalData.IsUiSceneLoading && !ControllerBase<CameraController>.Instance.IsSequenceCameraInCinematic("MainCamera"))
				{
					PlotModel instance3 = ModelBase<PlotModel>.Instance;
					flag = (instance3 != null && instance3.IsInPlot);
				}
				else
				{
					flag = true;
				}
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				foreach (CharRenderShell charRenderShell2 in this.AllRenderShell.Values)
				{
					try
					{
						if (charRenderShell2.IsAlwaysTick)
						{
							charRenderShell2.Tick((double)num2, false);
						}
					}
					catch (Exception ex3)
					{
						Log instance4 = Singleton<Log>.Instance;
						ELogModule module3 = ELogModule.Render;
						ELogAuthor author3 = ELogAuthor.LSY;
						string message3 = "RenderShell Tick执行异常";
						Exception error3 = ex3;
						ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("error", ex3.Message);
						instance4.ErrorWithStack(module3, author3, message3, error3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
					}
				}
			}
			IL_1CB:
			if (!Singleton<TickSystem>.Instance.IsPaused)
			{
				foreach (WuYinQuBattleActor wuYinQuBattleActor in this.AllWuYinQuBattleActors.Values)
				{
					try
					{
						if (UKismetSystemLibrary.IsValid(wuYinQuBattleActor))
						{
							string b = wuYinQuBattleActor.Key.ToString();
							if (this.CurrentBattleKey == b)
							{
								if (this.CurrentBattleState != wuYinQuBattleActor.GetCurrentBattleState())
								{
									wuYinQuBattleActor.ChangeState(this.CurrentBattleState, this.IsStateInstantTransition());
								}
							}
							else if (wuYinQuBattleActor.GetCurrentBattleState() != EWuYinQuState.StateIdle)
							{
								wuYinQuBattleActor.ChangeState(EWuYinQuState.StateIdle, this.IsStateInstantTransition());
							}
							wuYinQuBattleActor.Tick(delta);
						}
					}
					catch (Exception ex4)
					{
						Log instance5 = Singleton<Log>.Instance;
						ELogModule module4 = ELogModule.Render;
						ELogAuthor author4 = ELogAuthor.LSY;
						string message4 = "WuYinQuBattleActor 执行异常";
						Exception error4 = ex4;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("error", ex4.Message);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("object", wuYinQuBattleActor);
						instance5.ErrorWithStack(module4, author4, message4, error4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
				}
			}
			try
			{
				Singleton<RenderDataManager>.Instance.TickForce(delta);
				if (!Singleton<TickSystem>.Instance.IsPaused)
				{
					Singleton<RenderDataManager>.Instance.Tick(delta);
				}
			}
			catch (Exception ex5)
			{
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Render;
				ELogAuthor author5 = ELogAuthor.LSY;
				string message5 = "RenderDataManager Tick执行异常";
				Exception error5 = ex5;
				ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("error", ex5.Message);
				instance6.ErrorWithStack(module5, author5, message5, error5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
			}
			try
			{
				if (!Singleton<TickSystem>.Instance.IsPaused)
				{
					SceneInteractionManager.Get().Tick(delta);
				}
			}
			catch (Exception ex6)
			{
				Log instance7 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Render;
				ELogAuthor author6 = ELogAuthor.LSY;
				string message6 = "SceneInteractionManager Tick执行异常";
				Exception error6 = ex6;
				ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("error", ex6.Message);
				instance7.ErrorWithStack(module6, author6, message6, error6, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
			}
			try
			{
				Singleton<ItemMaterialManager>.Instance.Tick(delta);
			}
			catch (Exception ex7)
			{
				Log instance8 = Singleton<Log>.Instance;
				ELogModule module7 = ELogModule.Render;
				ELogAuthor author7 = ELogAuthor.LSY;
				string message7 = "ItemMaterialManager Tick执行异常";
				Exception error7 = ex7;
				ValueTuple<string, object> valueTuple6 = new ValueTuple<string, object>("error", ex7.Message);
				instance8.ErrorWithStack(module7, author7, message7, error7, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple6));
			}
			try
			{
				if (!Singleton<TickSystem>.Instance.IsPaused)
				{
					DebugDrawManager.Tick(delta);
				}
			}
			catch (Exception ex8)
			{
				Log instance9 = Singleton<Log>.Instance;
				ELogModule module8 = ELogModule.Render;
				ELogAuthor author8 = ELogAuthor.LSY;
				string message8 = "DebugDrawManager Tick执行异常";
				Exception error8 = ex8;
				ValueTuple<string, object> valueTuple7 = new ValueTuple<string, object>("error", ex8.Message);
				instance9.ErrorWithStack(module8, author8, message8, error8, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple7));
			}
			try
			{
				if (Singleton<Info>.Instance.IsGameRunning() && this.UltraSkillCounter > (float)(-(float)this.UltraSkillCounterMax) && this.UltraSkillCounter < (float)this.UltraSkillCounterMax)
				{
					this.UltraSkillCounter += (this.IsInUltraSkill ? num2 : (-num2));
					UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.World, this.MpcForGameplay, this.mpcForGameplayNameBurstTime, this.UltraSkillCounter);
				}
			}
			catch (Exception ex9)
			{
				Log instance10 = Singleton<Log>.Instance;
				ELogModule module9 = ELogModule.Render;
				ELogAuthor author9 = ELogAuthor.LSY;
				string message9 = "MpcForGameplay设置异常";
				Exception error9 = ex9;
				ValueTuple<string, object> valueTuple8 = new ValueTuple<string, object>("error", ex9.Message);
				instance10.ErrorWithStack(module9, author9, message9, error9, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple8));
			}
		}

		// Token: 0x0602F7B5 RID: 194485 RVA: 0x00B49950 File Offset: 0x00B47B50
		protected override bool OnInit()
		{
			this.BattleRefCount = 0;
			this.TickableObjects = new List<IRenderModuleTickableObject>();
			this.AllRenderShell = new Dictionary<CharRenderingComponent, CharRenderShell>();
			this.AllWuYinQuBattleActors = new Dictionary<string, WuYinQuBattleActor>();
			this.CurrentBattleKey = null;
			this.CurrentBattleState = EWuYinQuState.StateIdle;
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "初始化BOSS战渲染模块", default(ReadOnlySpan<ValueTuple<string, object>>));
			RenderDataManager instance = Singleton<RenderDataManager>.Instance;
			EffectManagerBusinessProxy instance2 = Singleton<EffectManagerBusinessProxy>.Instance;
			SceneInteractionManager.Initialize();
			Singleton<ItemMaterialManager>.Instance.Initialize();
			DebugDrawManager.Initialize();
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnStartTeleport));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnCompleteTeleport));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnEnterOrExitUltraSkill, new Action<bool>(this.OnEnterOrExitUltraSkill));
			Singleton<EventSystem>.Instance.Add<bool, string>(EEventName.OnSequenceCameraStatus, new Action<bool, string>(this.OnSequenceCameraStatus));
			Singleton<EventSystem>.Instance.Add<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.CameraModeChanged));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnSetGamePaused, new Action<bool>(this.OnSetGamePaused));
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			Singleton<ResourceSystem>.Instance.LoadAsync<UMaterialParameterCollection>("/Game/Aki/Render/Shaders/PostProcess/DistortionWave/MPC_ForGamePlay.MPC_ForGamePlay", delegate([Nullable(2)] UMaterialParameterCollection result, string path)
			{
				this.MpcForGameplay = result;
			}, 100, "js_undefined");
			return true;
		}

		// Token: 0x0602F7B6 RID: 194486 RVA: 0x00B49AD4 File Offset: 0x00B47CD4
		protected override bool OnClear()
		{
			this.DoClear();
			this.TickableObjects = new List<IRenderModuleTickableObject>();
			this.AllRenderShell = new Dictionary<CharRenderingComponent, CharRenderShell>();
			this.AllWuYinQuBattleActors = new Dictionary<string, WuYinQuBattleActor>();
			this.CurrentBattleKey = null;
			this.CurrentBattleState = EWuYinQuState.StateIdle;
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "清理BOSS战渲染模块", default(ReadOnlySpan<ValueTuple<string, object>>));
			Singleton<RenderDataManager>.Instance.Destroy();
			DebugDrawManager.Destroy();
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TeleportStart, new Action<bool>(this.OnStartTeleport));
			Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnCompleteTeleport));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnEnterOrExitUltraSkill, new Action<bool>(this.OnEnterOrExitUltraSkill));
			Singleton<EventSystem>.Instance.Remove<bool, string>(EEventName.OnSequenceCameraStatus, new Action<bool, string>(this.OnSequenceCameraStatus));
			Singleton<EventSystem>.Instance.Remove<ECustomCameraMode, ECustomCameraMode?, string>(EEventName.CameraModeChanged, new Action<ECustomCameraMode, ECustomCameraMode?, string>(this.CameraModeChanged));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnSetGamePaused, new Action<bool>(this.OnSetGamePaused));
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBattleStateChanged, new Action<bool>(this.OnBattleStateChanged));
			return true;
		}

		// Token: 0x0602F7B7 RID: 194487 RVA: 0x00B49C24 File Offset: 0x00B47E24
		protected override bool OnLeaveLevel()
		{
			this.TempDependenciesNotMatchDataLayerSet.Clear();
			foreach (string item in this.DependenciesNotMatchDataLayerSet)
			{
				this.TempDependenciesNotMatchDataLayerSet.Add(item);
			}
			this.DependenciesNotMatchDataLayerSet.Clear();
			this.DoClear();
			Singleton<Log>.Instance.Info(ELogModule.RenderBattle, ELogAuthor.HCS, "BOSS战渲染模块离开关卡", default(ReadOnlySpan<ValueTuple<string, object>>));
			return true;
		}

		// Token: 0x0602F7B8 RID: 194488 RVA: 0x00B49CB8 File Offset: 0x00B47EB8
		private void DoClear()
		{
			this.TickableObjects = new List<IRenderModuleTickableObject>();
			this.AllRenderShell = new Dictionary<CharRenderingComponent, CharRenderShell>();
			this.AllWuYinQuBattleActors = new Dictionary<string, WuYinQuBattleActor>();
			this.CurrentBattleKey = null;
			this.CurrentBattleState = EWuYinQuState.StateIdle;
			this.BattleRefCount = 0;
		}

		// Token: 0x0602F7B9 RID: 194489 RVA: 0x00B49CF0 File Offset: 0x00B47EF0
		public int EnableGlobalData(ItemMaterialControllerGlobalData globalMaterialData)
		{
			return -1;
		}

		// Token: 0x0602F7BA RID: 194490 RVA: 0x00B49CF3 File Offset: 0x00B47EF3
		public int EnableActorData([Nullable(2)] ItemMaterialControllerActorData actorMaterialData, AActor actor)
		{
			if (actor != null && actorMaterialData != null)
			{
				return Singleton<ItemMaterialManager>.Instance.AddMaterialData(actor, actorMaterialData);
			}
			return -1;
		}

		// Token: 0x0602F7BB RID: 194491 RVA: 0x00B49D09 File Offset: 0x00B47F09
		public void DisableGlobal(int handle)
		{
		}

		// Token: 0x0602F7BC RID: 194492 RVA: 0x00B49D0B File Offset: 0x00B47F0B
		public void DisableAllGlobal()
		{
		}

		// Token: 0x0602F7BD RID: 194493 RVA: 0x00B49D0D File Offset: 0x00B47F0D
		public void DisableActorData(int handle)
		{
			Singleton<ItemMaterialManager>.Instance.DisableActorData(handle);
		}

		// Token: 0x0602F7BE RID: 194494 RVA: 0x00B49D1B File Offset: 0x00B47F1B
		public void DisableAllActorData()
		{
			Singleton<ItemMaterialManager>.Instance.DisableAllActorData();
		}

		// Token: 0x0602F7BF RID: 194495 RVA: 0x00B49D28 File Offset: 0x00B47F28
		public void UpdateItemMaterialParameterCollection(ItemMaterialControllerMPCData_C data)
		{
			ItemMaterialParameterCollectionController.UpdateMaterialParameterCollection(data, Singleton<RenderDataManager>.Instance.GetSceneInteractionMaterialParameterCollection());
		}

		// Token: 0x0602F7C0 RID: 194496 RVA: 0x00B49D3A File Offset: 0x00B47F3A
		private void OnStartTeleport(bool b)
		{
			UKuroRenderingRuntimeBPPluginBPLibrary.StopSomeWeatherBeforeTeleport(GlobalData.World);
		}

		// Token: 0x0602F7C1 RID: 194497 RVA: 0x00B49D48 File Offset: 0x00B47F48
		[NullableContext(2)]
		private void OnCompleteTeleport(TeleportContext teleportContext)
		{
			float interval = 100f;
			TimerSystem.Instance.Delay(delegate(float _)
			{
				UKuroRenderingRuntimeBPPluginBPLibrary.ResumeSomeWeatherAfterTeleport(GlobalData.World);
			}, interval, null, null, true, 1f);
		}

		// Token: 0x0602F7C2 RID: 194498 RVA: 0x00B49D90 File Offset: 0x00B47F90
		private void OnEnterOrExitUltraSkill(bool isEnter)
		{
			if (isEnter && !this.WasEffectPostProcessDisabled)
			{
				UKuroRenderingRuntimeBPPluginBPLibrary.SetDisableEffectPostProcessVolume(GlobalData.World, true, 4f);
				this.WasEffectPostProcessDisabled = true;
				Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LSY, "进入大招禁用特效后处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (!isEnter && this.WasEffectPostProcessDisabled)
			{
				UKuroRenderingRuntimeBPPluginBPLibrary.SetDisableEffectPostProcessVolume(GlobalData.World, false, 1f);
				this.WasEffectPostProcessDisabled = false;
				Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LSY, "退出大招启用特效后处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (!isEnter)
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					if (baseCharacter == null)
					{
						return;
					}
					CharRenderingComponent charRenderingComponent = baseCharacter.CharRenderingComponent;
					if (charRenderingComponent == null)
					{
						return;
					}
					charRenderingComponent.RefreshMaterialController();
				}, null, null);
			}
			this.IsInUltraSkill = isEnter;
			this.UltraSkillCounter = 0f;
		}

		// Token: 0x0602F7C3 RID: 194499 RVA: 0x00B49E5C File Offset: 0x00B4805C
		private void OnSequenceCameraStatus(bool isEnter, string cameraName)
		{
			if (cameraName != "MainCamera")
			{
				return;
			}
			if (!isEnter && this.WasEffectPostProcessDisabled)
			{
				UKuroRenderingRuntimeBPPluginBPLibrary.SetDisableEffectPostProcessVolume(GlobalData.World, false, 1f);
				this.WasEffectPostProcessDisabled = false;
				Singleton<Log>.Instance.Info(ELogModule.Render, ELogAuthor.LSY, "退出镜头启用特效后处理", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			if (!isEnter)
			{
				TimerSystem.Instance.Next(delegate(float _)
				{
					TsBaseCharacter baseCharacter = Global.BaseCharacter;
					if (baseCharacter == null)
					{
						return;
					}
					CharRenderingComponent charRenderingComponent = baseCharacter.CharRenderingComponent;
					if (charRenderingComponent == null)
					{
						return;
					}
					charRenderingComponent.RefreshMaterialController();
				}, null, null);
			}
		}

		// Token: 0x0602F7C4 RID: 194500 RVA: 0x00B49EE4 File Offset: 0x00B480E4
		private void CameraModeChanged(ECustomCameraMode newMode, ECustomCameraMode? oldMode, string cameraName)
		{
			if (cameraName != "MainCamera")
			{
				return;
			}
			if (newMode == ECustomCameraMode.Widget)
			{
				UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.DisableGlobalGITransition 1", null);
				return;
			}
			ECustomCameraMode? ecustomCameraMode = oldMode;
			ECustomCameraMode ecustomCameraMode2 = ECustomCameraMode.Widget;
			if (ecustomCameraMode.GetValueOrDefault() == ecustomCameraMode2 & ecustomCameraMode != null)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.Kuro.DisableGlobalGITransition 0", null);
				}, 500f, null, null, true, 1f);
			}
		}

		// Token: 0x0602F7C5 RID: 194501 RVA: 0x00B49F64 File Offset: 0x00B48164
		public void AddDependenciesNotMatchDataLayer(string path)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DependenciesNotMatchDataLayerSet添加DataLayer";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DependenciesNotMatchDataLayerSet.Add(path);
		}

		// Token: 0x0602F7C6 RID: 194502 RVA: 0x00B49FA5 File Offset: 0x00B481A5
		public bool IsDependenciesNotMatchDataLayer(string path)
		{
			return this.DependenciesNotMatchDataLayerSet.Contains(path);
		}

		// Token: 0x0602F7C7 RID: 194503 RVA: 0x00B49FB4 File Offset: 0x00B481B4
		public void RemoveDependenciesNotMatchDataLayer(string path)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.World;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "DependenciesNotMatchDataLayerSet移除DataLayer";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("path", path);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.DependenciesNotMatchDataLayerSet.Remove(path);
		}

		// Token: 0x0602F7C8 RID: 194504 RVA: 0x00B49FF8 File Offset: 0x00B481F8
		public void FlushTempDependenciesNotMatchDataLayers()
		{
			foreach (string item in this.TempDependenciesNotMatchDataLayerSet)
			{
				this.DependenciesNotMatchDataLayerSet.Add(item);
			}
		}

		// Token: 0x0401B1EF RID: 111087
		private List<IRenderModuleTickableObject> TickableObjects = new List<IRenderModuleTickableObject>();

		// Token: 0x0401B1F0 RID: 111088
		private Dictionary<CharRenderingComponent, CharRenderShell> AllRenderShell = new Dictionary<CharRenderingComponent, CharRenderShell>();

		// Token: 0x0401B1F1 RID: 111089
		private Dictionary<string, WuYinQuBattleActor> AllWuYinQuBattleActors = new Dictionary<string, WuYinQuBattleActor>();

		// Token: 0x0401B1F2 RID: 111090
		[Nullable(2)]
		private string CurrentBattleKey;

		// Token: 0x0401B1F3 RID: 111091
		private EWuYinQuState CurrentBattleState = EWuYinQuState.EWuYinQuState_MAX;

		// Token: 0x0401B1F4 RID: 111092
		private EWuYinQuState CurrentInputBattleState = EWuYinQuState.EWuYinQuState_MAX;

		// Token: 0x0401B1F5 RID: 111093
		private bool IsIdleClearAtmosphere;

		// Token: 0x0401B1F6 RID: 111094
		private bool InstantTransition;

		// Token: 0x0401B1F7 RID: 111095
		[Nullable(2)]
		private UMaterialParameterCollection MpcForGameplay;

		// Token: 0x0401B1F8 RID: 111096
		private readonly FName mpcForGameplayNameBurstTime = new FName("BurstTime");

		// Token: 0x0401B1F9 RID: 111097
		private readonly int UltraSkillCounterMax = 16;

		// Token: 0x0401B1FA RID: 111098
		private float UltraSkillCounter = -16f;

		// Token: 0x0401B1FB RID: 111099
		private bool IsInUltraSkill;

		// Token: 0x0401B1FC RID: 111100
		private int BattleRefCount;

		// Token: 0x0401B1FD RID: 111101
		private bool ForceTickCharRenderShellInternal;

		// Token: 0x0401B1FE RID: 111102
		private bool WasEffectPostProcessDisabled;

		// Token: 0x0401B1FF RID: 111103
		private readonly HashSet<string> TempDependenciesNotMatchDataLayerSet = new HashSet<string>();

		// Token: 0x0401B200 RID: 111104
		private readonly HashSet<string> DependenciesNotMatchDataLayerSet = new HashSet<string>();
	}
}
