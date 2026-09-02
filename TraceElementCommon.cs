using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000C29 RID: 3113
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TraceElementCommon : Singleton<TraceElementCommon>
{
	// Token: 0x060035C8 RID: 13768 RVA: 0x00032CA7 File Offset: 0x00030EA7
	public bool LineTrace(UTraceLineElement element, string profileKey)
	{
		return UKuroTraceLibrary.LineTrace(element, profileKey);
	}

	// Token: 0x060035C9 RID: 13769 RVA: 0x00032CB0 File Offset: 0x00030EB0
	public bool BoxTrace(UTraceBoxElement element, string profileKey)
	{
		return UKuroTraceLibrary.BoxTrace(element, profileKey);
	}

	// Token: 0x060035CA RID: 13770 RVA: 0x00032CB9 File Offset: 0x00030EB9
	public bool CapsuleTrace(UTraceCapsuleElement element, string profileKey)
	{
		return UKuroTraceLibrary.CapsuleTrace(element, profileKey);
	}

	// Token: 0x060035CB RID: 13771 RVA: 0x00032CC2 File Offset: 0x00030EC2
	public bool SphereTrace(UTraceSphereElement element, string profileKey)
	{
		return UKuroTraceLibrary.SphereTrace(element, profileKey);
	}

	// Token: 0x060035CC RID: 13772 RVA: 0x00032CCC File Offset: 0x00030ECC
	public bool ShapeTrace([Nullable(2)] UShapeComponent inShapeComp, UTraceBaseElement element, string traceTagName, string profileKey)
	{
		FName value = FNameUtil.GetDynamicFName(traceTagName).Value;
		return UKuroTraceLibrary.ShapeTrace(inShapeComp, element, value, profileKey);
	}

	// Token: 0x060035CD RID: 13773 RVA: 0x00032CF4 File Offset: 0x00030EF4
	public TraceHandle AsyncLineTrace(UTraceLineElement element, string profileKey, FAsyncTraceDelegate @delegate)
	{
		if (Singleton<Time>.Instance.Frame != this.LineTraceFrame)
		{
			this.LineTraceIndex = 0;
		}
		else
		{
			this.LineTraceIndex++;
		}
		this.LineTraceFrame = Singleton<Time>.Instance.Frame;
		TraceHandle result = new TraceHandle(this.LineTraceFrame, this.LineTraceIndex);
		UKuroTraceLibrary.AsyncLineTrace(element, profileKey, @delegate, (double)this.LineTraceFrame, (double)this.LineTraceIndex);
		return result;
	}

	// Token: 0x060035CE RID: 13774 RVA: 0x00032D64 File Offset: 0x00030F64
	public TraceHandle AsyncBoxTrace(UTraceBoxElement element, string profileKey, FAsyncTraceDelegate @delegate)
	{
		if (Singleton<Time>.Instance.Frame > this.BoxTraceFrame)
		{
			this.BoxTraceIndex = 0;
		}
		else
		{
			this.BoxTraceIndex++;
		}
		this.BoxTraceFrame = Singleton<Time>.Instance.Frame;
		TraceHandle result = new TraceHandle(this.BoxTraceFrame, this.BoxTraceIndex);
		UKuroTraceLibrary.AsyncBoxTrace(element, profileKey, @delegate, (double)this.BoxTraceFrame, (double)this.BoxTraceIndex);
		return result;
	}

	// Token: 0x060035CF RID: 13775 RVA: 0x00032DD4 File Offset: 0x00030FD4
	public TraceHandle AsyncCapsuleTrace(UTraceCapsuleElement element, string profileKey, FAsyncTraceDelegate @delegate)
	{
		if (Singleton<Time>.Instance.Frame > this.CapsuleTraceFrame)
		{
			this.CapsuleTraceIndex = 0;
		}
		else
		{
			this.CapsuleTraceIndex++;
		}
		this.CapsuleTraceFrame = Singleton<Time>.Instance.Frame;
		TraceHandle result = new TraceHandle(this.CapsuleTraceFrame, this.CapsuleTraceIndex);
		UKuroTraceLibrary.AsyncCapsuleTrace(element, profileKey, @delegate, (double)this.CapsuleTraceFrame, (double)this.CapsuleTraceIndex);
		return result;
	}

	// Token: 0x060035D0 RID: 13776 RVA: 0x00032E44 File Offset: 0x00031044
	public TraceHandle AsyncSphereTrace(UTraceSphereElement element, string profileKey, FAsyncTraceDelegate @delegate)
	{
		if (Singleton<Time>.Instance.Frame > this.SphereTraceFrame)
		{
			this.SphereTraceIndex = 0;
		}
		else
		{
			this.SphereTraceIndex++;
		}
		this.SphereTraceFrame = Singleton<Time>.Instance.Frame;
		TraceHandle result = new TraceHandle(this.SphereTraceFrame, this.SphereTraceIndex);
		UKuroTraceLibrary.AsyncSphereTrace(element, profileKey, @delegate, (double)this.SphereTraceFrame, (double)this.SphereTraceIndex);
		return result;
	}

	// Token: 0x060035D1 RID: 13777 RVA: 0x00032EB2 File Offset: 0x000310B2
	public void SetStartLocation(UTraceBaseElement element, IVector location)
	{
		element.SetStartLocation(location.X, location.Y, location.Z);
	}

	// Token: 0x060035D2 RID: 13778 RVA: 0x00032ECC File Offset: 0x000310CC
	public void SetEndLocation(UTraceBaseElement element, IVector location)
	{
		element.SetEndLocation(location.X, location.Y, location.Z);
	}

	// Token: 0x060035D3 RID: 13779 RVA: 0x00032EE6 File Offset: 0x000310E6
	public void SetTraceColor(UTraceBaseElement element, FLinearColor color)
	{
		element.SetTraceColor(color.R, color.G, color.B, color.A);
	}

	// Token: 0x060035D4 RID: 13780 RVA: 0x00032F06 File Offset: 0x00031106
	public void SetTraceHitColor(UTraceBaseElement element, FLinearColor color)
	{
		element.SetTraceHitColor(color.R, color.G, color.B, color.A);
	}

	// Token: 0x060035D5 RID: 13781 RVA: 0x00032F26 File Offset: 0x00031126
	public void SetBoxHalfSize(UTraceBoxElement boxElement, IVector size)
	{
		boxElement.SetBoxHalfSize((float)size.X, (float)size.Y, (float)size.Z);
	}

	// Token: 0x060035D6 RID: 13782 RVA: 0x00032F43 File Offset: 0x00031143
	public void SetBoxOrientation(UTraceBoxElement boxElement, IRotator rotator)
	{
		boxElement.SetBoxOrientation(rotator.Pitch, rotator.Yaw, rotator.Roll);
	}

	// Token: 0x060035D7 RID: 13783 RVA: 0x00032F5D File Offset: 0x0003115D
	public void SetCapsuleOrientation(UTraceCapsuleElement capsuleElement, IRotator rotator)
	{
		capsuleElement.SetCapsuleOrientation(rotator.Pitch, rotator.Yaw, rotator.Roll);
	}

	// Token: 0x060035D8 RID: 13784 RVA: 0x00032F78 File Offset: 0x00031178
	public void GetHitLocation([Nullable(2)] UKuroHitResult hitResult, int index, IVector @out)
	{
		if (hitResult == null || !hitResult.bBlockingHit)
		{
			return;
		}
		@out.X = (double)hitResult.LocationX_Array.Get(index);
		@out.Y = (double)hitResult.LocationY_Array.Get(index);
		@out.Z = (double)hitResult.LocationZ_Array.Get(index);
	}

	// Token: 0x060035D9 RID: 13785 RVA: 0x00032FCC File Offset: 0x000311CC
	public void GetImpactPoint(UKuroHitResult hitResult, int index, IVector @out)
	{
		if (!hitResult.bBlockingHit)
		{
			return;
		}
		@out.X = (double)hitResult.ImpactPointX_Array.Get(index);
		@out.Y = (double)hitResult.ImpactPointY_Array.Get(index);
		@out.Z = (double)hitResult.ImpactPointZ_Array.Get(index);
	}

	// Token: 0x060035DA RID: 13786 RVA: 0x0003301C File Offset: 0x0003121C
	public void GetImpactNormal([Nullable(2)] UKuroHitResult hitResult, int index, IVector @out)
	{
		if (hitResult == null || !hitResult.bBlockingHit)
		{
			return;
		}
		@out.X = (double)hitResult.ImpactNormalX_Array.Get(index);
		@out.Y = (double)hitResult.ImpactNormalY_Array.Get(index);
		@out.Z = (double)hitResult.ImpactNormalZ_Array.Get(index);
	}

	// Token: 0x060035DB RID: 13787 RVA: 0x00033070 File Offset: 0x00031270
	public bool IsHitOthers(UKuroHitResult hitResult, AActor fromActor, AActor toActor)
	{
		if (!hitResult.bBlockingHit)
		{
			return false;
		}
		int num = hitResult.Actors.Num();
		int num2 = 0;
		if (num2 >= num)
		{
			return false;
		}
		AActor aactor = hitResult.Actors.Get(num2);
		if (aactor == null)
		{
			return true;
		}
		while (aactor != null)
		{
			if (aactor != fromActor && aactor != toActor)
			{
				aactor = aactor.GetAttachParentActor();
			}
		}
		return true;
	}

	// Token: 0x040006A8 RID: 1704
	private const bool OPEN_PROFILE_TEST = true;

	// Token: 0x040006A9 RID: 1705
	private const string NO_PROFILE_KEY = "";

	// Token: 0x040006AA RID: 1706
	private int LineTraceFrame;

	// Token: 0x040006AB RID: 1707
	private int LineTraceIndex;

	// Token: 0x040006AC RID: 1708
	private int BoxTraceFrame;

	// Token: 0x040006AD RID: 1709
	private int BoxTraceIndex;

	// Token: 0x040006AE RID: 1710
	private int CapsuleTraceFrame;

	// Token: 0x040006AF RID: 1711
	private int CapsuleTraceIndex;

	// Token: 0x040006B0 RID: 1712
	private int SphereTraceFrame;

	// Token: 0x040006B1 RID: 1713
	private int SphereTraceIndex;
}
