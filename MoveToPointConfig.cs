using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030DF RID: 12511
[NullableContext(2)]
[Nullable(0)]
public class MoveToPointConfig : IMoveToPointConfig, IStaticVariableResetter
{
	// Token: 0x06019D6B RID: 105835 RVA: 0x0078E17B File Offset: 0x0078C37B
	static MoveToPointConfig()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(MoveToPointConfig.CreateStaticDefaultValue), new Action(MoveToPointConfig.ResetStaticDefaultValue));
	}

	// Token: 0x170022DE RID: 8926
	// (get) Token: 0x06019D6C RID: 105836 RVA: 0x0078E19A File Offset: 0x0078C39A
	// (set) Token: 0x06019D6D RID: 105837 RVA: 0x0078E1A2 File Offset: 0x0078C3A2
	[Nullable(1)]
	public Vector Position
	{
		[NullableContext(1)]
		get
		{
			return this.PositionInternal;
		}
		[NullableContext(1)]
		set
		{
			this.PositionInternal = value;
		}
	}

	// Token: 0x170022DF RID: 8927
	// (get) Token: 0x06019D6E RID: 105838 RVA: 0x0078E1AB File Offset: 0x0078C3AB
	// (set) Token: 0x06019D6F RID: 105839 RVA: 0x0078E1B3 File Offset: 0x0078C3B3
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Func<Vector> ReferencePosition { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x06019D70 RID: 105840 RVA: 0x0078E1BC File Offset: 0x0078C3BC
	public bool UpdateTargetPosition()
	{
		if (this.ReferencePosition != null && !this.HasNextPoint())
		{
			this.PositionInternal.DeepCopy(this.ReferencePosition());
			return true;
		}
		return false;
	}

	// Token: 0x170022E0 RID: 8928
	// (get) Token: 0x06019D71 RID: 105841 RVA: 0x0078E1E7 File Offset: 0x0078C3E7
	// (set) Token: 0x06019D72 RID: 105842 RVA: 0x0078E1EF File Offset: 0x0078C3EF
	public bool? IsFly { get; set; }

	// Token: 0x170022E1 RID: 8929
	// (get) Token: 0x06019D73 RID: 105843 RVA: 0x0078E1F8 File Offset: 0x0078C3F8
	// (set) Token: 0x06019D74 RID: 105844 RVA: 0x0078E200 File Offset: 0x0078C400
	public bool? IsForward { get; set; }

	// Token: 0x170022E2 RID: 8930
	// (get) Token: 0x06019D75 RID: 105845 RVA: 0x0078E209 File Offset: 0x0078C409
	// (set) Token: 0x06019D76 RID: 105846 RVA: 0x0078E211 File Offset: 0x0078C411
	public float? ReturnTimeoutFailed { get; set; }

	// Token: 0x170022E3 RID: 8931
	// (get) Token: 0x06019D77 RID: 105847 RVA: 0x0078E21A File Offset: 0x0078C41A
	// (set) Token: 0x06019D78 RID: 105848 RVA: 0x0078E222 File Offset: 0x0078C422
	public double? Distance { get; set; } = new double?((double)MoveToPointConfig.DefaultDistance);

	// Token: 0x170022E4 RID: 8932
	// (get) Token: 0x06019D79 RID: 105849 RVA: 0x0078E22B File Offset: 0x0078C42B
	// (set) Token: 0x06019D7A RID: 105850 RVA: 0x0078E233 File Offset: 0x0078C433
	public float? TurnSpeed { get; set; } = new float?(MoveToPointConfig.DefaultTurnSpeed);

	// Token: 0x170022E5 RID: 8933
	// (get) Token: 0x06019D7B RID: 105851 RVA: 0x0078E23C File Offset: 0x0078C43C
	// (set) Token: 0x06019D7C RID: 105852 RVA: 0x0078E244 File Offset: 0x0078C444
	public ECharMoveState? MoveState { get; set; }

	// Token: 0x170022E6 RID: 8934
	// (get) Token: 0x06019D7D RID: 105853 RVA: 0x0078E24D File Offset: 0x0078C44D
	// (set) Token: 0x06019D7E RID: 105854 RVA: 0x0078E255 File Offset: 0x0078C455
	public bool? UseNearestDirection { get; set; }

	// Token: 0x170022E7 RID: 8935
	// (get) Token: 0x06019D7F RID: 105855 RVA: 0x0078E25E File Offset: 0x0078C45E
	// (set) Token: 0x06019D80 RID: 105856 RVA: 0x0078E266 File Offset: 0x0078C466
	public float? MoveSpeed { get; set; }

	// Token: 0x170022E8 RID: 8936
	// (get) Token: 0x06019D81 RID: 105857 RVA: 0x0078E26F File Offset: 0x0078C46F
	// (set) Token: 0x06019D82 RID: 105858 RVA: 0x0078E277 File Offset: 0x0078C477
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Queue<Vector> NextMovePointConfig { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022E9 RID: 8937
	// (get) Token: 0x06019D83 RID: 105859 RVA: 0x0078E280 File Offset: 0x0078C480
	// (set) Token: 0x06019D84 RID: 105860 RVA: 0x0078E288 File Offset: 0x0078C488
	public Vector FaceToPosition { get; set; }

	// Token: 0x170022EA RID: 8938
	// (get) Token: 0x06019D85 RID: 105861 RVA: 0x0078E291 File Offset: 0x0078C491
	// (set) Token: 0x06019D86 RID: 105862 RVA: 0x0078E299 File Offset: 0x0078C499
	public Func<bool> ResetCondition { get; set; }

	// Token: 0x170022EB RID: 8939
	// (get) Token: 0x06019D87 RID: 105863 RVA: 0x0078E2A2 File Offset: 0x0078C4A2
	// (set) Token: 0x06019D88 RID: 105864 RVA: 0x0078E2AA File Offset: 0x0078C4AA
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<Action<ELevelEventState>> CallbackList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022EC RID: 8940
	// (get) Token: 0x06019D89 RID: 105865 RVA: 0x0078E2B3 File Offset: 0x0078C4B3
	// (set) Token: 0x06019D8A RID: 105866 RVA: 0x0078E2BB File Offset: 0x0078C4BB
	public bool? ForceResetOnLargeDelta { get; set; } = new bool?(false);

	// Token: 0x170022ED RID: 8941
	// (get) Token: 0x06019D8B RID: 105867 RVA: 0x0078E2C4 File Offset: 0x0078C4C4
	// (set) Token: 0x06019D8C RID: 105868 RVA: 0x0078E2CC File Offset: 0x0078C4CC
	public int? LargeDeltaResetMinMove { get; set; } = new int?(120);

	// Token: 0x06019D8D RID: 105869 RVA: 0x0078E2D8 File Offset: 0x0078C4D8
	[NullableContext(1)]
	public MoveToPointConfig(IMoveToPointConfig config, [Nullable(2)] Vector cacheVector = null)
	{
		if (cacheVector != null)
		{
			this.PositionInternal = cacheVector;
		}
		else
		{
			this.PositionInternal = Vector.Create();
		}
		this.PositionInternal.DeepCopy(config.Position);
		this.NextMovePointConfig = (config.NextMovePointConfig ?? null);
		this.Distance = ((config.Distance.GetValueOrDefault() != 0.0) ? config.Distance : new double?((double)MoveToPointConfig.DefaultDistance));
		this.TurnSpeed = ((config.TurnSpeed.GetValueOrDefault() != 0f) ? config.TurnSpeed : new float?(MoveToPointConfig.DefaultTurnSpeed));
		ECharMoveState? moveState = config.MoveState;
		this.MoveState = ((moveState != null) ? moveState : null);
		this.IsFly = config.IsFly;
		this.IsForward = config.IsForward;
		this.ReturnTimeoutFailed = ((config.ReturnTimeoutFailed.GetValueOrDefault() != 0f) ? config.ReturnTimeoutFailed : new float?(0f));
		this.UseNearestDirection = config.UseNearestDirection;
		float? moveSpeed = config.MoveSpeed;
		this.MoveSpeed = ((moveSpeed != null) ? moveSpeed : null);
		this.FaceToPosition = (config.FaceToPosition ?? null);
		this.CallbackList = new List<Action<ELevelEventState>>();
		if (config.CallbackList != null && config.CallbackList.Count > 0)
		{
			this.CallbackList.AddRange(config.CallbackList);
		}
		if (config.ResetCondition != null)
		{
			this.ResetCondition = config.ResetCondition;
		}
		if (config.ReferencePosition != null)
		{
			this.ReferencePosition = config.ReferencePosition;
		}
		this.ForceResetOnLargeDelta = new bool?(config.ForceResetOnLargeDelta.GetValueOrDefault());
		this.LargeDeltaResetMinMove = new int?(config.LargeDeltaResetMinMove.GetValueOrDefault(120));
	}

	// Token: 0x06019D8E RID: 105870 RVA: 0x0078E4F4 File Offset: 0x0078C6F4
	[NullableContext(1)]
	public void DeepCopy(IMoveToPointConfig config)
	{
		this.PositionInternal.DeepCopy(config.Position);
		this.Distance = ((config.Distance.GetValueOrDefault() != 0.0) ? config.Distance : new double?((double)MoveToPointConfig.DefaultDistance));
		this.TurnSpeed = ((config.TurnSpeed.GetValueOrDefault() != 0f) ? config.TurnSpeed : new float?(MoveToPointConfig.DefaultTurnSpeed));
		ECharMoveState? moveState = config.MoveState;
		this.MoveState = ((moveState != null) ? moveState : null);
		this.IsFly = config.IsFly;
		this.IsForward = config.IsForward;
		this.ReturnTimeoutFailed = ((config.ReturnTimeoutFailed.GetValueOrDefault() != 0f) ? config.ReturnTimeoutFailed : new float?(0f));
		this.UseNearestDirection = config.UseNearestDirection;
		this.MoveSpeed = config.MoveSpeed;
		this.FaceToPosition = config.FaceToPosition;
		this.CallbackList = config.CallbackList;
		this.ResetCondition = config.ResetCondition;
		this.ReferencePosition = config.ReferencePosition;
		this.ForceResetOnLargeDelta = new bool?(config.ForceResetOnLargeDelta.GetValueOrDefault());
		this.LargeDeltaResetMinMove = new int?(config.LargeDeltaResetMinMove.GetValueOrDefault(120));
		this.NextMovePointConfig = config.NextMovePointConfig;
	}

	// Token: 0x06019D8F RID: 105871 RVA: 0x0078E664 File Offset: 0x0078C864
	public void RunCallbackList(ELevelEventState result)
	{
		if (this.CallbackList == null || this.CallbackList.Count == 0)
		{
			return;
		}
		foreach (Action<ELevelEventState> action in this.CallbackList)
		{
			if (action != null)
			{
				action(result);
			}
		}
	}

	// Token: 0x06019D90 RID: 105872 RVA: 0x0078E6D0 File Offset: 0x0078C8D0
	public void Clear()
	{
		if (this.CallbackList != null)
		{
			this.CallbackList.Clear();
		}
		this.ResetCondition = null;
		this.NextMovePointConfig = null;
	}

	// Token: 0x06019D91 RID: 105873 RVA: 0x0078E6F4 File Offset: 0x0078C8F4
	public bool UpdateNextPoint()
	{
		if (this.NextMovePointConfig != null && !this.NextMovePointConfig.Empty)
		{
			Vector inV = this.NextMovePointConfig.Pop();
			this.PositionInternal.DeepCopy(inV);
			return true;
		}
		return false;
	}

	// Token: 0x06019D92 RID: 105874 RVA: 0x0078E731 File Offset: 0x0078C931
	public bool HasNextPoint()
	{
		return this.NextMovePointConfig != null && !this.NextMovePointConfig.Empty;
	}

	// Token: 0x06019D93 RID: 105875 RVA: 0x0078E74B File Offset: 0x0078C94B
	public static void CreateStaticDefaultValue()
	{
		MoveToPointConfig.DefaultDistance = 30f;
		MoveToPointConfig.DefaultTurnSpeed = 360f;
	}

	// Token: 0x06019D94 RID: 105876 RVA: 0x0078E761 File Offset: 0x0078C961
	public static void ResetStaticDefaultValue()
	{
		MoveToPointConfig.DefaultDistance = 0f;
		MoveToPointConfig.DefaultTurnSpeed = 0f;
	}

	// Token: 0x0400CECF RID: 52943
	public static float DefaultDistance;

	// Token: 0x0400CED0 RID: 52944
	public static float DefaultTurnSpeed;

	// Token: 0x0400CED1 RID: 52945
	private Vector PositionInternal;
}
