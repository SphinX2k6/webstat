using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002364 RID: 9060
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class PanoramicModel : ModelBase<PanoramicModel>
{
	// Token: 0x1700158D RID: 5517
	// (get) Token: 0x06011544 RID: 70980 RVA: 0x004C516E File Offset: 0x004C336E
	// (set) Token: 0x06011545 RID: 70981 RVA: 0x004C5176 File Offset: 0x004C3376
	public bool IsPanoramic
	{
		get
		{
			return this.Panoramic;
		}
		set
		{
			this.Panoramic = value;
		}
	}

	// Token: 0x1700158E RID: 5518
	// (get) Token: 0x06011546 RID: 70982 RVA: 0x004C517F File Offset: 0x004C337F
	// (set) Token: 0x06011547 RID: 70983 RVA: 0x004C5187 File Offset: 0x004C3387
	public int PlayMoveMotorTag
	{
		get
		{
			return this.MotorTag;
		}
		set
		{
			this.MotorTag = value;
		}
	}

	// Token: 0x06011548 RID: 70984 RVA: 0x004C5190 File Offset: 0x004C3390
	protected override bool OnInit()
	{
		this.CurrentPanoramic = null;
		this.Activated = false;
		this.Panoramic = false;
		this.AllPoints = new Dictionary<long, PanoramicPointComponent>();
		return true;
	}

	// Token: 0x06011549 RID: 70985 RVA: 0x004C51B3 File Offset: 0x004C33B3
	protected override bool OnClear()
	{
		this.CurrentPanoramic = null;
		this.Activated = false;
		this.Panoramic = false;
		this.ClearPoint();
		return true;
	}

	// Token: 0x0601154A RID: 70986 RVA: 0x004C51D1 File Offset: 0x004C33D1
	protected override bool OnLeaveLevel()
	{
		this.CurrentPanoramic = null;
		this.Activated = false;
		this.Panoramic = false;
		this.ClearPoint();
		return true;
	}

	// Token: 0x0601154B RID: 70987 RVA: 0x004C51F0 File Offset: 0x004C33F0
	[NullableContext(1)]
	public void AddPoint(long num, PanoramicPointComponent comp)
	{
		if (this.AllPoints == null)
		{
			this.AllPoints = new Dictionary<long, PanoramicPointComponent>();
		}
		Dictionary<long, PanoramicPointComponent> allPoints = this.AllPoints;
		if (allPoints != null && allPoints.ContainsKey(num))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Panoramic;
			ELogAuthor author = ELogAuthor.JYS;
			string message = "[环视] AddPoint but already have";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		if (this.AllPoints != null)
		{
			this.AllPoints[num] = comp;
		}
	}

	// Token: 0x0601154C RID: 70988 RVA: 0x004C526C File Offset: 0x004C346C
	public void RemovePoint(long num)
	{
		Dictionary<long, PanoramicPointComponent> allPoints = this.AllPoints;
		if (allPoints == null || !allPoints.ContainsKey(num))
		{
			return;
		}
		Dictionary<long, PanoramicPointComponent> allPoints2 = this.AllPoints;
		PanoramicPointComponent panoramicPointComponent = (allPoints2 != null) ? allPoints2.GetValueOrDefault(num) : null;
		if (this.CurrentPanoramic == panoramicPointComponent)
		{
			this.CurrentPanoramic = null;
		}
		Dictionary<long, PanoramicPointComponent> allPoints3 = this.AllPoints;
		if (allPoints3 == null)
		{
			return;
		}
		allPoints3.Remove(num);
	}

	// Token: 0x0601154D RID: 70989 RVA: 0x004C52C8 File Offset: 0x004C34C8
	public void ClearPoint()
	{
		Singleton<Log>.Instance.Info(ELogModule.Panoramic, ELogAuthor.JYS, "[环视] ClearPoint", default(ReadOnlySpan<ValueTuple<string, object>>));
		Dictionary<long, PanoramicPointComponent> allPoints = this.AllPoints;
		if (allPoints != null)
		{
			allPoints.Clear();
		}
		this.AllPoints = null;
	}

	// Token: 0x0601154E RID: 70990 RVA: 0x004C530C File Offset: 0x004C350C
	public PanoramicPointComponent FindPoint(long num)
	{
		Dictionary<long, PanoramicPointComponent> allPoints = this.AllPoints;
		if (allPoints == null || !allPoints.ContainsKey(num))
		{
			Singleton<Log>.Instance.Warn(ELogModule.Panoramic, ELogAuthor.JYS, "[环视] FindPoint not find", default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}
		Dictionary<long, PanoramicPointComponent> allPoints2 = this.AllPoints;
		if (allPoints2 == null)
		{
			return null;
		}
		return allPoints2.GetValueOrDefault(num);
	}

	// Token: 0x0601154F RID: 70991 RVA: 0x004C5364 File Offset: 0x004C3564
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public Dictionary<long, PanoramicPointComponent> GetPoint()
	{
		return this.AllPoints;
	}

	// Token: 0x06011550 RID: 70992 RVA: 0x004C536C File Offset: 0x004C356C
	public int GetPointNum()
	{
		Dictionary<long, PanoramicPointComponent> allPoints = this.AllPoints;
		if (allPoints == null)
		{
			return 0;
		}
		return allPoints.Count;
	}

	// Token: 0x06011551 RID: 70993 RVA: 0x004C5380 File Offset: 0x004C3580
	public void SetCurrentPanoramic(PanoramicPointComponent value, bool noUpdate = false)
	{
		if (value == null)
		{
			if (noUpdate)
			{
				this.CurrentPanoramic = null;
				return;
			}
			this.ChangeAllPanoramicType(EPanoramicType.Default);
			if (this.Activated)
			{
				this.Activated = false;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPanoramicDisable);
			}
			return;
		}
		else
		{
			if (!this.Activated)
			{
				this.Activated = true;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnPanoramicActive);
			}
			int? num = (value != null) ? new int?(value.GetId()) : null;
			PanoramicPointComponent currentPanoramic = this.CurrentPanoramic;
			int? num2 = (currentPanoramic != null) ? new int?(currentPanoramic.GetId()) : null;
			if (num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null))
			{
				PanoramicPointComponent currentPanoramic2 = this.CurrentPanoramic;
				if (currentPanoramic2 == null)
				{
					return;
				}
				currentPanoramic2.ChangeSpotType(EPanoramicType.Active);
				return;
			}
			else
			{
				EPanoramicType type = EPanoramicType.Default;
				num2 = ((value != null) ? new int?(value.GetId()) : null);
				this.ChangeAllPanoramicTypeExecptWhich(type, (num2 != null) ? new long?((long)num2.GetValueOrDefault()) : null);
				this.CurrentPanoramic = value;
				PanoramicPointComponent currentPanoramic3 = this.CurrentPanoramic;
				if (currentPanoramic3 == null)
				{
					return;
				}
				currentPanoramic3.ChangeSpotType(EPanoramicType.Active);
				return;
			}
		}
	}

	// Token: 0x06011552 RID: 70994 RVA: 0x004C54AA File Offset: 0x004C36AA
	public PanoramicPointComponent GetCurrentPanoramic()
	{
		return this.CurrentPanoramic;
	}

	// Token: 0x06011553 RID: 70995 RVA: 0x004C54B4 File Offset: 0x004C36B4
	public void ChangeAllPanoramicType(EPanoramicType type)
	{
		if (this.AllPoints != null)
		{
			foreach (PanoramicPointComponent panoramicPointComponent in this.AllPoints.Values)
			{
				panoramicPointComponent.ChangeSpotType(type);
			}
		}
	}

	// Token: 0x06011554 RID: 70996 RVA: 0x004C5514 File Offset: 0x004C3714
	public void ChangeAllPanoramicTypeExecptWhich(EPanoramicType type, long? id)
	{
		if (this.AllPoints != null)
		{
			foreach (PanoramicPointComponent panoramicPointComponent in this.AllPoints.Values)
			{
				long num = (long)panoramicPointComponent.GetId();
				long? num2 = id;
				if (!(num == num2.GetValueOrDefault() & num2 != null))
				{
					panoramicPointComponent.ChangeSpotType(type);
				}
			}
		}
	}

	// Token: 0x04008821 RID: 34849
	private PanoramicPointComponent CurrentPanoramic;

	// Token: 0x04008822 RID: 34850
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<long, PanoramicPointComponent> AllPoints;

	// Token: 0x04008823 RID: 34851
	private bool Activated;

	// Token: 0x04008824 RID: 34852
	private bool Panoramic;

	// Token: 0x04008825 RID: 34853
	private int MotorTag;
}
