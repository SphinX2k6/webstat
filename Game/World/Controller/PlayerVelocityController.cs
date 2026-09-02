using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Teleport;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E6 RID: 18150
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class PlayerVelocityController : ControllerBase<PlayerVelocityController>
	{
		// Token: 0x0602F353 RID: 193363 RVA: 0x00B3005C File Offset: 0x00B2E25C
		protected override bool OnInit()
		{
			this.PlayerVelocityFilter = EntityToLoadFilter.Create();
			base.InitTickOptimize(5, 10);
			this.InitConsoleVariables();
			this.OnAddEvents();
			WaitEntityToLoadTask.GetPlayerVelocityOverride = new Func<Vector>(this.GetAvgVelocity);
			return base.OnInit();
		}

		// Token: 0x0602F354 RID: 193364 RVA: 0x00B30095 File Offset: 0x00B2E295
		private void InitConsoleVariables()
		{
			this.ImposterUpdateBatch = UKismetSystemLibrary.GetConsoleVariableIntValue("r.imp.UpdateBatch");
		}

		// Token: 0x0602F355 RID: 193365 RVA: 0x00B300A7 File Offset: 0x00B2E2A7
		protected override bool OnClear()
		{
			this.OnRemoveEvents();
			WaitEntityToLoadTask.GetPlayerVelocityOverride = null;
			this.PlayerVelocityFilter.Cleanup();
			return base.OnClear();
		}

		// Token: 0x0602F356 RID: 193366 RVA: 0x00B300C8 File Offset: 0x00B2E2C8
		private void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Add(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
			Singleton<EventSystem>.Instance.Add<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			Singleton<EventSystem>.Instance.Add<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportEnd));
		}

		// Token: 0x0602F357 RID: 193367 RVA: 0x00B30148 File Offset: 0x00B2E348
		private void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.BeforeLoadMap, new Action(this.OnBeforeLoadMap));
			Singleton<EventSystem>.Instance.Remove<bool>(EEventName.TeleportStart, new Action<bool>(this.OnTeleportStart));
			Singleton<EventSystem>.Instance.Remove<TeleportContext>(EEventName.TeleportComplete, new Action<TeleportContext>(this.OnTeleportEnd));
		}

		// Token: 0x0602F358 RID: 193368 RVA: 0x00B301C5 File Offset: 0x00B2E3C5
		private void OnWorldDone()
		{
			this.Start();
		}

		// Token: 0x0602F359 RID: 193369 RVA: 0x00B301CD File Offset: 0x00B2E3CD
		private void OnBeforeLoadMap()
		{
			this.Stop();
		}

		// Token: 0x0602F35A RID: 193370 RVA: 0x00B301D5 File Offset: 0x00B2E3D5
		private void OnTeleportStart(bool loading)
		{
			this.Stop();
		}

		// Token: 0x0602F35B RID: 193371 RVA: 0x00B301DD File Offset: 0x00B2E3DD
		[NullableContext(2)]
		private void OnTeleportEnd(TeleportContext teleportContext)
		{
			this.Start();
		}

		// Token: 0x0602F35C RID: 193372 RVA: 0x00B301E5 File Offset: 0x00B2E3E5
		private void Start()
		{
			base.ResumeTick();
			this.Reset();
		}

		// Token: 0x0602F35D RID: 193373 RVA: 0x00B301F3 File Offset: 0x00B2E3F3
		private void Stop()
		{
			base.PauseTick();
		}

		// Token: 0x0602F35E RID: 193374 RVA: 0x00B301FB File Offset: 0x00B2E3FB
		private void Reset()
		{
			this.LastPosition.DeepCopy(this.GetPlayerPosition());
			this.ResetVelocity();
		}

		// Token: 0x0602F35F RID: 193375 RVA: 0x00B30214 File Offset: 0x00B2E414
		private void ResetVelocity()
		{
			this.AvgVelocity.Set(0.0, 0.0, 0.0);
		}

		// Token: 0x0602F360 RID: 193376 RVA: 0x00B3023C File Offset: 0x00B2E43C
		protected override void OnTick(float delta)
		{
			this.CalculateVelocity(delta * 0.001f);
		}

		// Token: 0x0602F361 RID: 193377 RVA: 0x00B3024C File Offset: 0x00B2E44C
		private Vector GetPlayerPosition()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			CharacterActorComponent characterActorComponent;
			if (getCurrentEntity == null)
			{
				characterActorComponent = null;
			}
			else
			{
				WorldEntity entity = getCurrentEntity.Entity;
				characterActorComponent = ((entity != null) ? entity.GetComponent<CharacterActorComponent>() : null);
			}
			CharacterActorComponent characterActorComponent2 = characterActorComponent;
			if (characterActorComponent2 == null)
			{
				return this.LastPosition;
			}
			return characterActorComponent2.ActorLocationProxy;
		}

		// Token: 0x0602F362 RID: 193378 RVA: 0x00B3028C File Offset: 0x00B2E48C
		private void CalculateVelocity(float delta)
		{
			if (delta <= 0f)
			{
				if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.World;
					ELogAuthor author = ELogAuthor.XY;
					string message = "计算玩家移动速度时检测到间隔时间异常";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("delta", delta);
					instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				this.ResetVelocity();
			}
			else if (delta > 5f)
			{
				if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.World;
					ELogAuthor author2 = ELogAuthor.XY;
					string message2 = "计算玩家移动速度时检测到间隔时间过长";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("delta", delta);
					instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				}
				this.Reset();
			}
			else
			{
				Vector playerPosition = this.GetPlayerPosition();
				playerPosition.Subtraction(this.LastPosition, this.AbsVelocity);
				this.AbsVelocity.DivisionEqual((double)delta);
				this.LastPosition.DeepCopy(playerPosition);
				float num = MathCommon.Clamp(delta * 6f, 0f, 1f);
				this.AvgVelocity.MultiplyEqual((double)(1f - num));
				this.AbsVelocity.MultiplyEqual((double)num);
				this.AvgVelocity.AdditionEqual(this.AbsVelocity);
			}
			this.UpdateHighSpeedMode();
		}

		// Token: 0x0602F363 RID: 193379 RVA: 0x00B303B4 File Offset: 0x00B2E5B4
		private unsafe void UpdateHighSpeedMode()
		{
			double num = this.AvgVelocity.SizeSquared();
			bool flag = num > 640000.0;
			if (flag == this.IsHighSpeed)
			{
				return;
			}
			this.IsHighSpeed = flag;
			if (ModelBase<CreatureModel>.Instance.EnableEntityLog)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.World;
				ELogAuthor author = ELogAuthor.XY;
				string message = "高速模式切换";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsHighSpeed", this.IsHighSpeed);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("AvgVelocity", num);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			if (!ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
			{
				this.UpdateConsoleVariables();
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnHighSpeedModeChanged, this.IsHighSpeed);
		}

		// Token: 0x0602F364 RID: 193380 RVA: 0x00B30481 File Offset: 0x00B2E681
		private void UpdateConsoleVariables()
		{
			if (this.IsHighSpeed)
			{
				this.UpdateImposterUpdateBatch((int)Math.Floor((double)((float)this.ImposterUpdateBatch / 2f)));
				return;
			}
			this.UpdateImposterUpdateBatch(this.ImposterUpdateBatch);
		}

		// Token: 0x0602F365 RID: 193381 RVA: 0x00B304B2 File Offset: 0x00B2E6B2
		private void UpdateImposterUpdateBatch(int batch)
		{
			this.TempStringArray[0] = "r.imp.UpdateBatch";
			this.TempStringArray[1] = batch.ToString();
			UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, string.Join(" ", this.TempStringArray), null);
		}

		// Token: 0x0602F366 RID: 193382 RVA: 0x00B304EB File Offset: 0x00B2E6EB
		public Vector GetAvgVelocity()
		{
			return this.AvgVelocity;
		}

		// Token: 0x0602F367 RID: 193383 RVA: 0x00B304F3 File Offset: 0x00B2E6F3
		public bool IsHighSpeedMode()
		{
			return this.IsHighSpeed;
		}

		// Token: 0x0401AE62 RID: 110178
		private const float MAX_DELTA_TIME = 5f;

		// Token: 0x0401AE63 RID: 110179
		private const int HIGH_SPEED_SQUARED = 640000;

		// Token: 0x0401AE64 RID: 110180
		private const string IMPOSTER_UPDATE_BATCH = "r.imp.UpdateBatch";

		// Token: 0x0401AE65 RID: 110181
		private readonly Vector LastPosition = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x0401AE66 RID: 110182
		private readonly Vector AbsVelocity = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x0401AE67 RID: 110183
		private readonly Vector AvgVelocity = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x0401AE68 RID: 110184
		private bool IsHighSpeed;

		// Token: 0x0401AE69 RID: 110185
		private int ImposterUpdateBatch = 128;

		// Token: 0x0401AE6A RID: 110186
		private readonly string[] TempStringArray = new string[]
		{
			"",
			"0"
		};

		// Token: 0x0401AE6B RID: 110187
		private readonly Stat CalculateVelocityStat = Stat.Create("PlayerVelocityController.CalculateVelocity", "", "");

		// Token: 0x0401AE6C RID: 110188
		private EntityToLoadFilter PlayerVelocityFilter;
	}
}
