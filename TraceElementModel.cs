using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x020034BD RID: 13501
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TraceElementModel : ModelBase<TraceElementModel>
{
	// Token: 0x0601C8A4 RID: 116900 RVA: 0x0088EF64 File Offset: 0x0088D164
	protected override bool OnClear()
	{
		if (this.SpecificTraceTypeElement != null)
		{
			foreach (UTraceBaseElement utraceBaseElement in this.SpecificTraceTypeElement.Values)
			{
				utraceBaseElement.Dispose();
			}
			this.SpecificTraceTypeElement.Clear();
			this.SpecificTraceTypeElement = null;
		}
		if (this.ActorTrace != null)
		{
			this.ActorTrace.Dispose();
			this.ActorTrace = null;
		}
		if (this.BoxTrace != null)
		{
			this.BoxTrace.Dispose();
			this.BoxTrace = null;
		}
		if (this.CapsuleTrace != null)
		{
			this.CapsuleTrace.Dispose();
			this.CapsuleTrace = null;
		}
		return true;
	}

	// Token: 0x0601C8A5 RID: 116901 RVA: 0x0088F024 File Offset: 0x0088D224
	[Obsolete]
	public UTraceSphereElement GetActorTrace()
	{
		if (this.ActorTrace == null)
		{
			this.InitActorTraceInternal();
		}
		return this.ActorTrace;
	}

	// Token: 0x0601C8A6 RID: 116902 RVA: 0x0088F03A File Offset: 0x0088D23A
	[Obsolete]
	public void ClearActorTrace()
	{
		if (this.ActorTrace != null)
		{
			this.ActorTrace.WorldContextObject = null;
			this.ActorTrace.ActorsToIgnore.Empty(true);
		}
	}

	// Token: 0x0601C8A7 RID: 116903 RVA: 0x0088F064 File Offset: 0x0088D264
	private void InitActorTraceInternal()
	{
		UTraceSphereElement utraceSphereElement = new UTraceSphereElement();
		utraceSphereElement.bIsSingle = false;
		utraceSphereElement.bIgnoreSelf = true;
		utraceSphereElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceSphereElement, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceSphereElement, ColorUtils.LinearRed);
		this.ActorTrace = utraceSphereElement;
	}

	// Token: 0x0601C8A8 RID: 116904 RVA: 0x0088F0B7 File Offset: 0x0088D2B7
	[Obsolete]
	public UTraceLineElement GetLineTrace()
	{
		if (this.LineTrace == null)
		{
			this.InitLineTraceInternal();
		}
		return this.LineTrace;
	}

	// Token: 0x0601C8A9 RID: 116905 RVA: 0x0088F0CD File Offset: 0x0088D2CD
	[Obsolete]
	public void ClearLineTrace()
	{
		if (this.LineTrace != null)
		{
			this.LineTrace.WorldContextObject = null;
			this.LineTrace.ActorsToIgnore.Empty(true);
		}
	}

	// Token: 0x0601C8AA RID: 116906 RVA: 0x0088F0F4 File Offset: 0x0088D2F4
	private void InitLineTraceInternal()
	{
		UTraceLineElement utraceLineElement = new UTraceLineElement();
		utraceLineElement.bIsSingle = true;
		utraceLineElement.bIgnoreSelf = true;
		utraceLineElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceLineElement, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceLineElement, ColorUtils.LinearRed);
		this.LineTrace = utraceLineElement;
	}

	// Token: 0x0601C8AB RID: 116907 RVA: 0x0088F147 File Offset: 0x0088D347
	[Obsolete]
	public UTraceBoxElement GetBoxTrace()
	{
		if (this.BoxTrace == null)
		{
			this.InitBoxTraceInternal();
		}
		return this.BoxTrace;
	}

	// Token: 0x0601C8AC RID: 116908 RVA: 0x0088F15D File Offset: 0x0088D35D
	[Obsolete]
	public void ClearBoxTrace()
	{
		if (this.BoxTrace != null)
		{
			this.BoxTrace.WorldContextObject = null;
			this.BoxTrace.ActorsToIgnore.Empty(true);
		}
	}

	// Token: 0x0601C8AD RID: 116909 RVA: 0x0088F184 File Offset: 0x0088D384
	private void InitBoxTraceInternal()
	{
		UTraceBoxElement utraceBoxElement = new UTraceBoxElement();
		utraceBoxElement.bIsSingle = true;
		utraceBoxElement.bIgnoreSelf = true;
		utraceBoxElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceBoxElement, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceBoxElement, ColorUtils.LinearRed);
		this.BoxTrace = utraceBoxElement;
	}

	// Token: 0x0601C8AE RID: 116910 RVA: 0x0088F1D7 File Offset: 0x0088D3D7
	[Obsolete]
	public UTraceCapsuleElement GetCapsuleTrace()
	{
		if (this.CapsuleTrace == null)
		{
			this.InitCapsuleTraceInternal();
		}
		return this.CapsuleTrace;
	}

	// Token: 0x0601C8AF RID: 116911 RVA: 0x0088F1ED File Offset: 0x0088D3ED
	[Obsolete]
	public void ClearCapsuleTrace()
	{
		if (this.CapsuleTrace != null)
		{
			this.CapsuleTrace.WorldContextObject = null;
			this.CapsuleTrace.ActorsToIgnore.Empty(true);
		}
	}

	// Token: 0x0601C8B0 RID: 116912 RVA: 0x0088F214 File Offset: 0x0088D414
	private void InitCapsuleTraceInternal()
	{
		UTraceCapsuleElement utraceCapsuleElement = new UTraceCapsuleElement();
		utraceCapsuleElement.bIsSingle = true;
		utraceCapsuleElement.bIgnoreSelf = true;
		utraceCapsuleElement.SetTraceTypeQuery(KuroTraceTypeQuery.IkGround);
		Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceCapsuleElement, ColorUtils.LinearGreen);
		Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceCapsuleElement, ColorUtils.LinearRed);
		this.CapsuleTrace = utraceCapsuleElement;
	}

	// Token: 0x0601C8B1 RID: 116913 RVA: 0x0088F268 File Offset: 0x0088D468
	[NullableContext(1)]
	private T GetElement<[Nullable(0)] T>([Nullable(new byte[]
	{
		0,
		1
	})] TSubclassOf<UTraceBaseElement> elementClass, UObject worldContextObject, bool isSingle, bool ignoreSelf) where T : UTraceBaseElement
	{
		if (this.SpecificTraceTypeElement == null)
		{
			this.SpecificTraceTypeElement = new Dictionary<TSubclassOf<UTraceBaseElement>, UTraceBaseElement>();
		}
		if (!this.SpecificTraceTypeElement.ContainsKey(elementClass))
		{
			UTraceBaseElement utraceBaseElement = UGameplayStatics.SpawnObject(elementClass, worldContextObject) as UTraceBaseElement;
			Singleton<TraceElementCommon>.Instance.SetTraceColor(utraceBaseElement, ColorUtils.LinearGreen);
			Singleton<TraceElementCommon>.Instance.SetTraceHitColor(utraceBaseElement, ColorUtils.LinearRed);
			this.SpecificTraceTypeElement[elementClass] = utraceBaseElement;
		}
		T t = (T)((object)this.SpecificTraceTypeElement[elementClass]);
		t.ClearCacheData(true);
		t.ActorsToIgnore.Empty(true);
		t.bIsSingle = isSingle;
		t.bIgnoreSelf = ignoreSelf;
		t.WorldContextObject = worldContextObject;
		if (this.ShowDebugTrace)
		{
			t.SetDrawDebugTrace(EDrawDebugTrace.ForDuration);
		}
		return t;
	}

	// Token: 0x0601C8B2 RID: 116914 RVA: 0x0088F33E File Offset: 0x0088D53E
	[NullableContext(1)]
	public T GetTraceTypeElement<[Nullable(0)] T>([Nullable(new byte[]
	{
		0,
		1
	})] TSubclassOf<UTraceBaseElement> elementClass, ETraceTypeQuery traceTypeQuery, UObject worldContextObject, bool isSingle = true, bool ignoreSelf = true) where T : UTraceBaseElement
	{
		T element = this.GetElement<T>(elementClass, worldContextObject, isSingle, ignoreSelf);
		element.SetTraceTypeQuery(traceTypeQuery);
		return element;
	}

	// Token: 0x0601C8B3 RID: 116915 RVA: 0x0088F358 File Offset: 0x0088D558
	[NullableContext(1)]
	public T GetObjectTypeElement<[Nullable(0)] T>([Nullable(new byte[]
	{
		0,
		1
	})] TSubclassOf<UTraceBaseElement> elementClass, EObjectTypeQuery[] objectTypeQueries, UObject worldContextObject, bool isSingle = true, bool ignoreSelf = true) where T : UTraceBaseElement
	{
		T element = this.GetElement<T>(elementClass, worldContextObject, isSingle, ignoreSelf);
		TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
		foreach (EObjectTypeQuery value in objectTypeQueries)
		{
			tarray.Add(value);
		}
		element.SetObjectTypesQuery(ref tarray);
		return element;
	}

	// Token: 0x0601C8B4 RID: 116916 RVA: 0x0088F3A8 File Offset: 0x0088D5A8
	[NullableContext(1)]
	public T GetObjectTypeElement<[Nullable(0)] T>([Nullable(new byte[]
	{
		0,
		1
	})] TSubclassOf<UTraceBaseElement> elementClass, EObjectTypeQuery objectTypeQuery, UObject worldContextObject, bool isSingle = true, bool ignoreSelf = true) where T : UTraceBaseElement
	{
		return this.GetObjectTypeElement<T>(elementClass, new EObjectTypeQuery[]
		{
			objectTypeQuery
		}, worldContextObject, isSingle, ignoreSelf);
	}

	// Token: 0x0400E5CB RID: 58827
	private UTraceSphereElement ActorTrace;

	// Token: 0x0400E5CC RID: 58828
	private UTraceLineElement LineTrace;

	// Token: 0x0400E5CD RID: 58829
	[Nullable(1)]
	public Vector CommonStartLocation = Vector.Create();

	// Token: 0x0400E5CE RID: 58830
	[Nullable(1)]
	public Vector CommonEndLocation = Vector.Create();

	// Token: 0x0400E5CF RID: 58831
	[Nullable(1)]
	public Vector CommonHitLocation = Vector.Create();

	// Token: 0x0400E5D0 RID: 58832
	private UTraceBoxElement BoxTrace;

	// Token: 0x0400E5D1 RID: 58833
	private UTraceCapsuleElement CapsuleTrace;

	// Token: 0x0400E5D2 RID: 58834
	[Nullable(new byte[]
	{
		2,
		0,
		1,
		1
	})]
	private Dictionary<TSubclassOf<UTraceBaseElement>, UTraceBaseElement> SpecificTraceTypeElement;

	// Token: 0x0400E5D3 RID: 58835
	public bool ShowDebugTrace;
}
