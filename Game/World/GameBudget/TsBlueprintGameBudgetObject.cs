using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.World.GameBudget
{
	// Token: 0x020046D8 RID: 18136
	[NullableContext(1)]
	[Nullable(0)]
	public class TsBlueprintGameBudgetObject : IGameBudgetManagedObject
	{
		// Token: 0x0602F2A0 RID: 193184 RVA: 0x00B2CB40 File Offset: 0x00B2AD40
		public TsBlueprintGameBudgetObject(AActor actor)
		{
			this.Actor = actor;
			this.ScheduledTickMethod = actor.GetType().GetMethod("ScheduledTick", new Type[]
			{
				typeof(float)
			});
		}

		// Token: 0x0602F2A1 RID: 193185 RVA: 0x00B2CB78 File Offset: 0x00B2AD78
		public bool HasScheduledTickMethod()
		{
			return this.ScheduledTickMethod != null;
		}

		// Token: 0x0602F2A2 RID: 193186 RVA: 0x00B2CB88 File Offset: 0x00B2AD88
		public uint RegisterTick(TsGameBudgetGroupConfigCache groupConfig)
		{
			if (this.HasRegister)
			{
				return 0U;
			}
			this.HasRegister = true;
			if (!this.GameBudgetGCHandle.IsAllocated)
			{
				this.GameBudgetGCHandle = GCHandle.Alloc(this, GCHandleType.Normal);
			}
			return Singleton<GameBudgetInterfaceController>.Instance.RegisterTick(groupConfig.GroupName, groupConfig.SignificanceGroup, this, this.Actor, true, true, true, true);
		}

		// Token: 0x0602F2A3 RID: 193187 RVA: 0x00B2CBE1 File Offset: 0x00B2ADE1
		public void UnregisterTick()
		{
			if (!this.HasRegister)
			{
				return;
			}
			this.HasRegister = false;
			Singleton<GameBudgetInterfaceController>.Instance.UnregisterTick(this);
			if (this.GameBudgetGCHandle.IsAllocated)
			{
				this.GameBudgetGCHandle.Free();
			}
		}

		// Token: 0x0602F2A4 RID: 193188 RVA: 0x00B2CC18 File Offset: 0x00B2AE18
		public void ScheduledTick(float deltaSeconds, int deltaFrames, float distance)
		{
			AActor actor = this.Actor;
			if (actor == null || !actor.IsValid())
			{
				Singleton<Log>.Instance.Error(ELogModule.Game, ELogAuthor.WLJ, "TsBlueprintGameBudgetObject Tick Invalid Actor", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.UnregisterTick();
				return;
			}
			if (this.ScheduledTickMethod != null)
			{
				this.ScheduledTickMethod.Invoke(this.Actor, new object[]
				{
					deltaSeconds
				});
			}
		}

		// Token: 0x1700811D RID: 33053
		// (get) Token: 0x0602F2A5 RID: 193189 RVA: 0x00B2CC8E File Offset: 0x00B2AE8E
		public bool HasScheduledAfterTick
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0602F2A6 RID: 193190 RVA: 0x00B2CC91 File Offset: 0x00B2AE91
		void IGameBudgetManagedObject.ScheduledAfterTick(float deltaSeconds, int deltaFrames, float distance)
		{
		}

		// Token: 0x1700811E RID: 33054
		// (get) Token: 0x0602F2A7 RID: 193191 RVA: 0x00B2CC93 File Offset: 0x00B2AE93
		public bool HasOnEnabledChange
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0602F2A8 RID: 193192 RVA: 0x00B2CC96 File Offset: 0x00B2AE96
		void IGameBudgetManagedObject.OnEnabledChange(bool enable, float distance)
		{
		}

		// Token: 0x1700811F RID: 33055
		// (get) Token: 0x0602F2A9 RID: 193193 RVA: 0x00B2CC98 File Offset: 0x00B2AE98
		public bool HasOnWasRecentlyRenderedOnScreenChange
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0602F2AA RID: 193194 RVA: 0x00B2CC9B File Offset: 0x00B2AE9B
		void IGameBudgetManagedObject.OnWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
		{
		}

		// Token: 0x17008120 RID: 33056
		// (get) Token: 0x0602F2AB RID: 193195 RVA: 0x00B2CC9D File Offset: 0x00B2AE9D
		public bool HasLocationProxyFunction
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0602F2AC RID: 193196 RVA: 0x00B2CCA0 File Offset: 0x00B2AEA0
		FVectorDouble? IGameBudgetManagedObject.LocationProxyFunction()
		{
			return null;
		}

		// Token: 0x0602F2AD RID: 193197 RVA: 0x00B2CCB6 File Offset: 0x00B2AEB6
		public GCHandle GetGCHandle()
		{
			return this.GameBudgetGCHandle;
		}

		// Token: 0x0401ADDB RID: 110043
		public AActor Actor;

		// Token: 0x0401ADDC RID: 110044
		[Nullable(2)]
		private readonly MethodInfo ScheduledTickMethod;

		// Token: 0x0401ADDD RID: 110045
		private bool HasRegister;

		// Token: 0x0401ADDE RID: 110046
		private GCHandle GameBudgetGCHandle;
	}
}
