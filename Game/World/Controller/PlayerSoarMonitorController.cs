using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Framework;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.World.Controller
{
	// Token: 0x020046E5 RID: 18149
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[TickController(0)]
	public class PlayerSoarMonitorController : ControllerBase<PlayerSoarMonitorController>
	{
		// Token: 0x17008143 RID: 33091
		// (get) Token: 0x0602F348 RID: 193352 RVA: 0x00B2FED5 File Offset: 0x00B2E0D5
		// (set) Token: 0x0602F349 RID: 193353 RVA: 0x00B2FEDD File Offset: 0x00B2E0DD
		public bool IsPlayerSoar
		{
			get
			{
				return this.IsPlayerSoarInternal;
			}
			set
			{
				if (this.IsPlayerSoarInternal == value)
				{
					return;
				}
				this.IsPlayerSoarInternal = value;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.PlayerSoarChanged, value);
			}
		}

		// Token: 0x17008144 RID: 33092
		// (get) Token: 0x0602F34A RID: 193354 RVA: 0x00B2FF01 File Offset: 0x00B2E101
		public bool EnableSlowStreaming
		{
			get
			{
				return this.EnableSlowStreamingInternal;
			}
		}

		// Token: 0x0602F34B RID: 193355 RVA: 0x00B2FF09 File Offset: 0x00B2E109
		protected override bool OnInit()
		{
			this.PlayerSoarMonitorFilter = EntityToLoadFilter.Create();
			base.InitTickOptimize(60, -1);
			this.InitConsoleVariables();
			return base.OnInit();
		}

		// Token: 0x0602F34C RID: 193356 RVA: 0x00B2FF2B File Offset: 0x00B2E12B
		private void InitConsoleVariables()
		{
			this.HeightThreshould = (float)UKismetSystemLibrary.GetConsoleVariableIntValue("wp.Runtime.SoraGridBlackListHeight");
			if (this.HeightThreshould <= 0f)
			{
				this.HeightThreshould = 1500f;
			}
		}

		// Token: 0x0602F34D RID: 193357 RVA: 0x00B2FF56 File Offset: 0x00B2E156
		protected override void OnTick(float deltaTime)
		{
			this.CheckPlayerMoveState();
			this.CheckEnableSlowStreaming();
		}

		// Token: 0x0602F34E RID: 193358 RVA: 0x00B2FF64 File Offset: 0x00B2E164
		protected override bool OnClear()
		{
			this.PlayerSoarMonitorFilter.Cleanup();
			return base.OnClear();
		}

		// Token: 0x0602F34F RID: 193359 RVA: 0x00B2FF78 File Offset: 0x00B2E178
		private void CheckPlayerMoveState()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				this.IsPlayerSoar = false;
				return;
			}
			CharacterUnifiedStateComponent component = getCurrentEntity.Entity.GetComponent<CharacterUnifiedStateComponent>();
			if (component == null)
			{
				this.IsPlayerSoar = false;
				return;
			}
			this.IsPlayerSoar = (component.MoveState == ECharMoveState.Soar);
		}

		// Token: 0x0602F350 RID: 193360 RVA: 0x00B2FFC4 File Offset: 0x00B2E1C4
		private void CheckEnableSlowStreaming()
		{
			bool flag = this.IsPlayerSoar && this.CheckHeight();
			if (this.EnableSlowStreamingInternal != flag)
			{
				this.EnableSlowStreamingInternal = flag;
				Singleton<EventSystem>.Instance.Emit<bool>(EEventName.SlowStreamingBySoar, this.EnableSlowStreamingInternal);
			}
		}

		// Token: 0x0602F351 RID: 193361 RVA: 0x00B3000C File Offset: 0x00B2E20C
		private bool CheckHeight()
		{
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return false;
			}
			CharacterMoveComponent component = getCurrentEntity.Entity.GetComponent<CharacterMoveComponent>();
			return component != null && component.GetHeightAboveGround(this.HeightThreshould + 1f) > this.HeightThreshould;
		}

		// Token: 0x0401AE5B RID: 110171
		public const int SLOW_STREAMING_HEIGHT_THRESHOULD = 1500;

		// Token: 0x0401AE5C RID: 110172
		private const string SLOW_STREAMING_HEIGHT_THRESHOULD_CVAR = "wp.Runtime.SoraGridBlackListHeight";

		// Token: 0x0401AE5D RID: 110173
		public const bool ENABLE_SLOW_STREAMING_ENTITY_FILTER = true;

		// Token: 0x0401AE5E RID: 110174
		private bool IsPlayerSoarInternal;

		// Token: 0x0401AE5F RID: 110175
		private bool EnableSlowStreamingInternal;

		// Token: 0x0401AE60 RID: 110176
		private EntityToLoadFilter PlayerSoarMonitorFilter;

		// Token: 0x0401AE61 RID: 110177
		public float HeightThreshould;
	}
}
