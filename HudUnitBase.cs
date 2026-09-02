using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F81 RID: 8065
public class HudUnitBase : UiPanelBase
{
	// Token: 0x0600F1A9 RID: 61865 RVA: 0x00420430 File Offset: 0x0041E630
	[NullableContext(1)]
	public UniTask Initialize(string resourceId, bool showAfterCreate, bool needSafeZone)
	{
		HudUnitBase.<Initialize>d__3 <Initialize>d__;
		<Initialize>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Initialize>d__.<>4__this = this;
		<Initialize>d__.resourceId = resourceId;
		<Initialize>d__.showAfterCreate = showAfterCreate;
		<Initialize>d__.needSafeZone = needSafeZone;
		<Initialize>d__.<>1__state = -1;
		<Initialize>d__.<>t__builder.Start<HudUnitBase.<Initialize>d__3>(ref <Initialize>d__);
		return <Initialize>d__.<>t__builder.Task;
	}

	// Token: 0x0600F1AA RID: 61866 RVA: 0x0042048B File Offset: 0x0041E68B
	public virtual void Tick(float delta)
	{
	}

	// Token: 0x0600F1AB RID: 61867 RVA: 0x0042048D File Offset: 0x0041E68D
	public virtual void AfterTick(float delta)
	{
	}

	// Token: 0x0600F1AC RID: 61868 RVA: 0x00420490 File Offset: 0x0041E690
	public void SetVisible(bool bVisible, int type = 0)
	{
		bool visible = this.GetVisible();
		this.VisibleState = VisibleStateUtil.SetVisible(this.VisibleState, bVisible, type);
		bool visible2 = this.GetVisible();
		if (visible == visible2 && base.GetActive() == visible2)
		{
			return;
		}
		this.SetActive(bVisible);
	}

	// Token: 0x0600F1AD RID: 61869 RVA: 0x004204D1 File Offset: 0x0041E6D1
	public bool GetVisible()
	{
		return VisibleStateUtil.GetVisible(this.VisibleState);
	}

	// Token: 0x0600F1AE RID: 61870 RVA: 0x004204DE File Offset: 0x0041E6DE
	protected override void OnBeforeDestroy()
	{
		if (this.TweenAnimMap != null)
		{
			this.TweenAnimMap.Clear();
		}
	}

	// Token: 0x0600F1AF RID: 61871 RVA: 0x004204F3 File Offset: 0x0041E6F3
	public void SetAnchorOffset(float x, float y)
	{
		if (this.RootItem == null)
		{
			return;
		}
		this.RootItem.SetAnchorOffsetX(x);
		this.RootItem.SetAnchorOffsetY(y);
	}

	// Token: 0x0600F1B0 RID: 61872 RVA: 0x00420518 File Offset: 0x0041E718
	protected void InitTweenAnim(int componentType)
	{
		List<ULGUIPlayTweenComponent> list = new List<ULGUIPlayTweenComponent>();
		TArray<UActorComponent> tarray = base.GetItem(componentType).GetOwner().K2_GetComponentsByClass(ULGUIPlayTweenComponent.StaticClass());
		int num = tarray.Num();
		for (int i = 0; i < num; i++)
		{
			list.Add(tarray.Get(i) as ULGUIPlayTweenComponent);
		}
		if (this.TweenAnimMap == null)
		{
			this.TweenAnimMap = new Dictionary<int, ULGUIPlayTweenComponent[]>();
		}
		this.TweenAnimMap[componentType] = list.ToArray();
	}

	// Token: 0x0600F1B1 RID: 61873 RVA: 0x00420594 File Offset: 0x0041E794
	protected void PlayTweenAnim(int componentType)
	{
		ULGUIPlayTweenComponent[] array;
		this.TweenAnimMap.TryGetValue(componentType, out array);
		if (array != null)
		{
			ULGUIPlayTweenComponent[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Play();
			}
		}
	}

	// Token: 0x0600F1B2 RID: 61874 RVA: 0x004205CC File Offset: 0x0041E7CC
	protected void StopTweenAnim(int componentType)
	{
		ULGUIPlayTweenComponent[] array;
		this.TweenAnimMap.TryGetValue(componentType, out array);
		if (array != null)
		{
			ULGUIPlayTweenComponent[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].Stop();
			}
		}
	}

	// Token: 0x040073FC RID: 29692
	[Nullable(2)]
	public string ResourceId;

	// Token: 0x040073FD RID: 29693
	protected int VisibleState;

	// Token: 0x040073FE RID: 29694
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected Dictionary<int, ULGUIPlayTweenComponent[]> TweenAnimMap;
}
