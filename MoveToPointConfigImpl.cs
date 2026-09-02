using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030E1 RID: 12513
[NullableContext(2)]
[Nullable(0)]
public class MoveToPointConfigImpl : IMoveToPointConfig
{
	// Token: 0x170022FE RID: 8958
	// (get) Token: 0x06019DB5 RID: 105909 RVA: 0x0078E777 File Offset: 0x0078C977
	// (set) Token: 0x06019DB6 RID: 105910 RVA: 0x0078E77F File Offset: 0x0078C97F
	[Nullable(1)]
	public Vector Position { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x170022FF RID: 8959
	// (get) Token: 0x06019DB7 RID: 105911 RVA: 0x0078E788 File Offset: 0x0078C988
	// (set) Token: 0x06019DB8 RID: 105912 RVA: 0x0078E790 File Offset: 0x0078C990
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

	// Token: 0x17002300 RID: 8960
	// (get) Token: 0x06019DB9 RID: 105913 RVA: 0x0078E799 File Offset: 0x0078C999
	// (set) Token: 0x06019DBA RID: 105914 RVA: 0x0078E7A1 File Offset: 0x0078C9A1
	public bool? IsFly { get; set; }

	// Token: 0x17002301 RID: 8961
	// (get) Token: 0x06019DBB RID: 105915 RVA: 0x0078E7AA File Offset: 0x0078C9AA
	// (set) Token: 0x06019DBC RID: 105916 RVA: 0x0078E7B2 File Offset: 0x0078C9B2
	public bool? IsForward { get; set; }

	// Token: 0x17002302 RID: 8962
	// (get) Token: 0x06019DBD RID: 105917 RVA: 0x0078E7BB File Offset: 0x0078C9BB
	// (set) Token: 0x06019DBE RID: 105918 RVA: 0x0078E7C3 File Offset: 0x0078C9C3
	public double? Distance { get; set; }

	// Token: 0x17002303 RID: 8963
	// (get) Token: 0x06019DBF RID: 105919 RVA: 0x0078E7CC File Offset: 0x0078C9CC
	// (set) Token: 0x06019DC0 RID: 105920 RVA: 0x0078E7D4 File Offset: 0x0078C9D4
	public ECharMoveState? MoveState { get; set; }

	// Token: 0x17002304 RID: 8964
	// (get) Token: 0x06019DC1 RID: 105921 RVA: 0x0078E7DD File Offset: 0x0078C9DD
	// (set) Token: 0x06019DC2 RID: 105922 RVA: 0x0078E7E5 File Offset: 0x0078C9E5
	public float? MoveSpeed { get; set; }

	// Token: 0x17002305 RID: 8965
	// (get) Token: 0x06019DC3 RID: 105923 RVA: 0x0078E7EE File Offset: 0x0078C9EE
	// (set) Token: 0x06019DC4 RID: 105924 RVA: 0x0078E7F6 File Offset: 0x0078C9F6
	public float? TurnSpeed { get; set; }

	// Token: 0x17002306 RID: 8966
	// (get) Token: 0x06019DC5 RID: 105925 RVA: 0x0078E7FF File Offset: 0x0078C9FF
	// (set) Token: 0x06019DC6 RID: 105926 RVA: 0x0078E807 File Offset: 0x0078CA07
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

	// Token: 0x17002307 RID: 8967
	// (get) Token: 0x06019DC7 RID: 105927 RVA: 0x0078E810 File Offset: 0x0078CA10
	// (set) Token: 0x06019DC8 RID: 105928 RVA: 0x0078E818 File Offset: 0x0078CA18
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

	// Token: 0x17002308 RID: 8968
	// (get) Token: 0x06019DC9 RID: 105929 RVA: 0x0078E821 File Offset: 0x0078CA21
	// (set) Token: 0x06019DCA RID: 105930 RVA: 0x0078E829 File Offset: 0x0078CA29
	public Func<bool> ResetCondition { get; set; }

	// Token: 0x17002309 RID: 8969
	// (get) Token: 0x06019DCB RID: 105931 RVA: 0x0078E832 File Offset: 0x0078CA32
	// (set) Token: 0x06019DCC RID: 105932 RVA: 0x0078E83A File Offset: 0x0078CA3A
	public bool? UseNearestDirection { get; set; }

	// Token: 0x1700230A RID: 8970
	// (get) Token: 0x06019DCD RID: 105933 RVA: 0x0078E843 File Offset: 0x0078CA43
	// (set) Token: 0x06019DCE RID: 105934 RVA: 0x0078E84B File Offset: 0x0078CA4B
	public Vector FaceToPosition { get; set; }

	// Token: 0x1700230B RID: 8971
	// (get) Token: 0x06019DCF RID: 105935 RVA: 0x0078E854 File Offset: 0x0078CA54
	// (set) Token: 0x06019DD0 RID: 105936 RVA: 0x0078E85C File Offset: 0x0078CA5C
	public float? ReturnTimeoutFailed { get; set; }

	// Token: 0x1700230C RID: 8972
	// (get) Token: 0x06019DD1 RID: 105937 RVA: 0x0078E865 File Offset: 0x0078CA65
	// (set) Token: 0x06019DD2 RID: 105938 RVA: 0x0078E86D File Offset: 0x0078CA6D
	public bool? ForceResetOnLargeDelta { get; set; }

	// Token: 0x1700230D RID: 8973
	// (get) Token: 0x06019DD3 RID: 105939 RVA: 0x0078E876 File Offset: 0x0078CA76
	// (set) Token: 0x06019DD4 RID: 105940 RVA: 0x0078E87E File Offset: 0x0078CA7E
	public int? LargeDeltaResetMinMove { get; set; }
}
