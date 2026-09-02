using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030E0 RID: 12512
[NullableContext(2)]
public interface IMoveToPointConfig
{
	// Token: 0x170022EE RID: 8942
	// (get) Token: 0x06019D95 RID: 105877
	// (set) Token: 0x06019D96 RID: 105878
	[Nullable(1)]
	Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170022EF RID: 8943
	// (get) Token: 0x06019D97 RID: 105879
	// (set) Token: 0x06019D98 RID: 105880
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Func<Vector> ReferencePosition { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022F0 RID: 8944
	// (get) Token: 0x06019D99 RID: 105881
	// (set) Token: 0x06019D9A RID: 105882
	bool? IsFly { get; set; }

	// Token: 0x170022F1 RID: 8945
	// (get) Token: 0x06019D9B RID: 105883
	// (set) Token: 0x06019D9C RID: 105884
	bool? IsForward { get; set; }

	// Token: 0x170022F2 RID: 8946
	// (get) Token: 0x06019D9D RID: 105885
	// (set) Token: 0x06019D9E RID: 105886
	double? Distance { get; set; }

	// Token: 0x170022F3 RID: 8947
	// (get) Token: 0x06019D9F RID: 105887
	// (set) Token: 0x06019DA0 RID: 105888
	ECharMoveState? MoveState { get; set; }

	// Token: 0x170022F4 RID: 8948
	// (get) Token: 0x06019DA1 RID: 105889
	// (set) Token: 0x06019DA2 RID: 105890
	float? MoveSpeed { get; set; }

	// Token: 0x170022F5 RID: 8949
	// (get) Token: 0x06019DA3 RID: 105891
	// (set) Token: 0x06019DA4 RID: 105892
	float? TurnSpeed { get; set; }

	// Token: 0x170022F6 RID: 8950
	// (get) Token: 0x06019DA5 RID: 105893
	// (set) Token: 0x06019DA6 RID: 105894
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Queue<Vector> NextMovePointConfig { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022F7 RID: 8951
	// (get) Token: 0x06019DA7 RID: 105895
	// (set) Token: 0x06019DA8 RID: 105896
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<Action<ELevelEventState>> CallbackList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x170022F8 RID: 8952
	// (get) Token: 0x06019DA9 RID: 105897
	// (set) Token: 0x06019DAA RID: 105898
	Func<bool> ResetCondition { get; set; }

	// Token: 0x170022F9 RID: 8953
	// (get) Token: 0x06019DAB RID: 105899
	// (set) Token: 0x06019DAC RID: 105900
	bool? UseNearestDirection { get; set; }

	// Token: 0x170022FA RID: 8954
	// (get) Token: 0x06019DAD RID: 105901
	// (set) Token: 0x06019DAE RID: 105902
	Vector FaceToPosition { get; set; }

	// Token: 0x170022FB RID: 8955
	// (get) Token: 0x06019DAF RID: 105903
	// (set) Token: 0x06019DB0 RID: 105904
	float? ReturnTimeoutFailed { get; set; }

	// Token: 0x170022FC RID: 8956
	// (get) Token: 0x06019DB1 RID: 105905
	// (set) Token: 0x06019DB2 RID: 105906
	bool? ForceResetOnLargeDelta { get; set; }

	// Token: 0x170022FD RID: 8957
	// (get) Token: 0x06019DB3 RID: 105907
	// (set) Token: 0x06019DB4 RID: 105908
	int? LargeDeltaResetMinMove { get; set; }
}
