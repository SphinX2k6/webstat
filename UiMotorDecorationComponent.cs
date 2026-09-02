using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002C9D RID: 11421
[NullableContext(2)]
[Nullable(0)]
public class UiMotorDecorationComponent : UiModelComponentBase
{
	// Token: 0x06016EC0 RID: 93888 RVA: 0x0065A909 File Offset: 0x00658B09
	protected override void OnInit()
	{
		this.ModelDataComponent = base.Owner.CheckGetComponent<UiModelDataComponent>();
		this.InitDecorationSkeletalObserver();
	}

	// Token: 0x06016EC1 RID: 93889 RVA: 0x0065A924 File Offset: 0x00658B24
	protected override void OnStart()
	{
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeMotorModelLoad));
		Singleton<EventSystem>.Instance.AddWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnMotorModelReady));
	}

	// Token: 0x06016EC2 RID: 93890 RVA: 0x0065A978 File Offset: 0x00658B78
	protected override void OnEnd()
	{
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.BeforeUiModelLoadStart, new Action(this.OnBeforeMotorModelLoad));
		Singleton<EventSystem>.Instance.RemoveWithTarget(base.Owner, EEventName.OnUiModelLoadComplete, new Action(this.OnMotorModelReady));
		this.RemoveAllDecorationSkeletalObserver();
	}

	// Token: 0x06016EC3 RID: 93891 RVA: 0x0065A9CF File Offset: 0x00658BCF
	public bool IsMotorModelLoaded()
	{
		UiModelDataComponent modelDataComponent = this.ModelDataComponent;
		return modelDataComponent != null && modelDataComponent.GetModelLoadState() == EUiModelLoadState.LoadComplete;
	}

	// Token: 0x06016EC4 RID: 93892 RVA: 0x0065A9E8 File Offset: 0x00658BE8
	public SkeletalObserverHandle GetDecorationHandle(int decorationPart, int index)
	{
		List<SkeletalObserverHandle> list;
		if (this.MotorDecorationMap.TryGetValue(decorationPart, out list) && index >= 0 && index < list.Count)
		{
			return list[index];
		}
		return null;
	}

	// Token: 0x06016EC5 RID: 93893 RVA: 0x0065AA1C File Offset: 0x00658C1C
	public void InitDecorationSkeletalObserver()
	{
		foreach (int key in MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART)
		{
			SkeletalObserverHandle item = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.MotorDecorationOnMotor);
			this.MotorDecorationMap[key] = new List<SkeletalObserverHandle>
			{
				item
			};
		}
	}

	// Token: 0x06016EC6 RID: 93894 RVA: 0x0065AA64 File Offset: 0x00658C64
	public void RemoveAllDecorationSkeletalObserver()
	{
		foreach (List<SkeletalObserverHandle> list in this.MotorDecorationMap.Values)
		{
			foreach (SkeletalObserverHandle skeletalObserverHandle in list)
			{
				SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
			}
		}
		this.MotorDecorationMap.Clear();
	}

	// Token: 0x06016EC7 RID: 93895 RVA: 0x0065AAF8 File Offset: 0x00658CF8
	public void RemoveDecorationSkeletalObserver(int decorationPart, int? index = null)
	{
		List<SkeletalObserverHandle> list;
		if (!this.MotorDecorationMap.TryGetValue(decorationPart, out list))
		{
			return;
		}
		if (index != null)
		{
			int value = index.Value;
			if (value >= 0 && value < list.Count)
			{
				SkeletalObserverManager.DestroySkeletalObserver(list[value]);
				list.RemoveAt(value);
				return;
			}
		}
		else
		{
			foreach (SkeletalObserverHandle skeletalObserverHandle in list)
			{
				SkeletalObserverManager.DestroySkeletalObserver(skeletalObserverHandle);
			}
			this.MotorDecorationMap.Remove(decorationPart);
		}
	}

	// Token: 0x06016EC8 RID: 93896 RVA: 0x0065AB94 File Offset: 0x00658D94
	public void ShowAllDecoration(bool isShow)
	{
		if (isShow && !this.IsMotorModelLoaded())
		{
			return;
		}
		foreach (List<SkeletalObserverHandle> list in this.MotorDecorationMap.Values)
		{
			foreach (SkeletalObserverHandle skeletalObserverHandle in list)
			{
				if (((skeletalObserverHandle != null) ? skeletalObserverHandle.Model : null) != null)
				{
					Singleton<UiModelUtil>.Instance.SetVisible(skeletalObserverHandle.Model, isShow);
				}
			}
		}
	}

	// Token: 0x06016EC9 RID: 93897 RVA: 0x0065AC48 File Offset: 0x00658E48
	public void AddDecorationMesh(int decorationPart, int decorationId)
	{
		SkeletalObserverHandle item = SkeletalObserverManager.NewSkeletalObserver(EUiModelUseWay.MotorDecorationOnMotor);
		List<SkeletalObserverHandle> list;
		if (!this.MotorDecorationMap.TryGetValue(decorationPart, out list))
		{
			list = new List<SkeletalObserverHandle>();
			this.MotorDecorationMap[decorationPart] = list;
		}
		list.Add(item);
	}

	// Token: 0x06016ECA RID: 93898 RVA: 0x0065AC87 File Offset: 0x00658E87
	private void OnBeforeMotorModelLoad()
	{
		this.ShowAllDecoration(false);
	}

	// Token: 0x06016ECB RID: 93899 RVA: 0x0065AC90 File Offset: 0x00658E90
	private void OnMotorModelReady()
	{
		this.ShowAllDecoration(true);
	}

	// Token: 0x0400B0C9 RID: 45257
	[Nullable(1)]
	private readonly Dictionary<int, List<SkeletalObserverHandle>> MotorDecorationMap = new Dictionary<int, List<SkeletalObserverHandle>>();

	// Token: 0x0400B0CA RID: 45258
	private UiModelDataComponent ModelDataComponent;
}
