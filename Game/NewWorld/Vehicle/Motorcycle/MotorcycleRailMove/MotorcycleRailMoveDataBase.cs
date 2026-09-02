using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;

namespace CSharpScript.Game.NewWorld.Vehicle.Motorcycle.MotorcycleRailMove
{
	// Token: 0x020047C5 RID: 18373
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class MotorcycleRailMoveDataBase
	{
		// Token: 0x0602FAE0 RID: 195296 RVA: 0x00B672AC File Offset: 0x00B654AC
		protected MotorcycleRailMoveDataBase(EMotorcycleRailMoveDataType type, Entity ownerEntity, [Nullable(2)] MotorcycleRailComponent relatedRail)
		{
		}

		// Token: 0x0602FAE1 RID: 195297 RVA: 0x00B672CC File Offset: 0x00B654CC
		[NullableContext(2)]
		public bool Enter(MotorcycleRailMoveDataBase lastRailMoveData)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorRailMove;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[MotorcycleRailMoveData] MotorcycleRailMoveData.Enter";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", this.Type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return this.OnEnter(lastRailMoveData);
		}

		// Token: 0x0602FAE2 RID: 195298 RVA: 0x00B67314 File Offset: 0x00B65514
		[NullableContext(2)]
		public virtual bool OnEnter(MotorcycleRailMoveDataBase lastRailMoveData)
		{
			return true;
		}

		// Token: 0x0602FAE3 RID: 195299 RVA: 0x00B67318 File Offset: 0x00B65518
		public void Exit()
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.MotorRailMove;
			ELogAuthor author = ELogAuthor.ZYL;
			string message = "[MotorcycleRailMoveData] MotorcycleRailMoveData.Exit";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Type", this.Type);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.OnExit();
		}

		// Token: 0x0602FAE4 RID: 195300 RVA: 0x00B6735F File Offset: 0x00B6555F
		public virtual void OnExit()
		{
		}

		// Token: 0x0602FAE5 RID: 195301 RVA: 0x00B67361 File Offset: 0x00B65561
		public void Tick(float deltaSeconds)
		{
			this.OnTick(deltaSeconds);
		}

		// Token: 0x0602FAE6 RID: 195302 RVA: 0x00B6736A File Offset: 0x00B6556A
		public virtual void OnTick(float deltaSeconds)
		{
		}

		// Token: 0x0602FAE7 RID: 195303 RVA: 0x00B6736C File Offset: 0x00B6556C
		public virtual bool GetVelocity(Vector outVelocity)
		{
			return false;
		}

		// Token: 0x0401B4D4 RID: 111828
		public EMotorcycleRailMoveDataType Type = type;

		// Token: 0x0401B4D5 RID: 111829
		public Entity OwnerEntity = ownerEntity;

		// Token: 0x0401B4D6 RID: 111830
		[Nullable(2)]
		public MotorcycleRailComponent RelatedRail = relatedRail;

		// Token: 0x0401B4D7 RID: 111831
		public bool IsFinishMove;

		// Token: 0x0401B4D8 RID: 111832
		public bool IsFinishMoveOnFailure;
	}
}
