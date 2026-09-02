using System;
using System.Runtime.CompilerServices;

// Token: 0x020020CD RID: 8397
[NullableContext(2)]
[Nullable(0)]
public class NormalLoadingViewGlobalData : IStaticVariableResetter
{
	// Token: 0x060100B5 RID: 65717 RVA: 0x00468442 File Offset: 0x00466642
	static NormalLoadingViewGlobalData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(NormalLoadingViewGlobalData.CreateStaticDefaultValue), new Action(NormalLoadingViewGlobalData.ResetStaticDefaultValue));
	}

	// Token: 0x060100B6 RID: 65718 RVA: 0x00468461 File Offset: 0x00466661
	public static void CreateFirstProgressPromise()
	{
		NormalLoadingViewGlobalData.FirstProgressPromiseInternal = new CustomPromise();
	}

	// Token: 0x060100B7 RID: 65719 RVA: 0x0046846D File Offset: 0x0046666D
	public static void FinishFirstProgressPromise()
	{
		NormalLoadingViewGlobalData.FirstProgressPromiseInternal.SetResult();
		NormalLoadingViewGlobalData.FirstProgressPromiseInternal = null;
	}

	// Token: 0x1700134A RID: 4938
	// (get) Token: 0x060100B8 RID: 65720 RVA: 0x0046847F File Offset: 0x0046667F
	public static CustomPromise FirstProgressPromise
	{
		get
		{
			return NormalLoadingViewGlobalData.FirstProgressPromiseInternal;
		}
	}

	// Token: 0x1700134B RID: 4939
	// (get) Token: 0x060100B9 RID: 65721 RVA: 0x00468486 File Offset: 0x00466686
	public static CustomPromise FinishPromise
	{
		get
		{
			return NormalLoadingViewGlobalData.FinishPromiseInternal;
		}
	}

	// Token: 0x060100BA RID: 65722 RVA: 0x0046848D File Offset: 0x0046668D
	public static void CreateFinishPromisePromise()
	{
		NormalLoadingViewGlobalData.FinishPromiseInternal = new CustomPromise();
	}

	// Token: 0x060100BB RID: 65723 RVA: 0x00468499 File Offset: 0x00466699
	public static void FinishEndPromise()
	{
		CustomPromise finishPromiseInternal = NormalLoadingViewGlobalData.FinishPromiseInternal;
		if (finishPromiseInternal != null)
		{
			finishPromiseInternal.SetResult();
		}
		NormalLoadingViewGlobalData.FinishPromiseInternal = null;
	}

	// Token: 0x1700134C RID: 4940
	// (get) Token: 0x060100BC RID: 65724 RVA: 0x004684B1 File Offset: 0x004666B1
	public static bool IsNotifyCloseView
	{
		get
		{
			return NormalLoadingViewGlobalData.IsNotifyCloseViewInternal;
		}
	}

	// Token: 0x060100BD RID: 65725 RVA: 0x004684B8 File Offset: 0x004666B8
	public static void ResetNotifyCloseView()
	{
		NormalLoadingViewGlobalData.IsNotifyCloseViewInternal = false;
	}

	// Token: 0x060100BE RID: 65726 RVA: 0x004684C0 File Offset: 0x004666C0
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x060100BF RID: 65727 RVA: 0x004684C2 File Offset: 0x004666C2
	public static void ResetStaticDefaultValue()
	{
		NormalLoadingViewGlobalData.FirstProgressPromiseInternal = null;
		NormalLoadingViewGlobalData.FinishPromiseInternal = null;
		NormalLoadingViewGlobalData.IsNotifyCloseViewInternal = false;
	}

	// Token: 0x04007B06 RID: 31494
	private static CustomPromise FirstProgressPromiseInternal;

	// Token: 0x04007B07 RID: 31495
	private static CustomPromise FinishPromiseInternal;

	// Token: 0x04007B08 RID: 31496
	private static bool IsNotifyCloseViewInternal;
}
