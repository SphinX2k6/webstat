using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.HotPatch;
using CSharpScript.Launcher.InputDevice;
using CSharpScript.Launcher.PlayerInput;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;
using UnrealEngine.Utils;

// Token: 0x020034E3 RID: 13539
[NullableContext(1)]
[Nullable(0)]
[UClass("/Game/Aki/TypeScript/Launcher/PlayerInput/", EClassFlags.CLASS_None)]
[UnrealObjectPath("/Game/Aki/TypeScript/Launcher/PlayerInput/TsHotPatchPanelConfig.TsHotPatchPanelConfig_C")]
public class TsHotPatchPanelConfig : ULGUIBehaviour, IUnrealUObject, IUnrealObject
{
	// Token: 0x170026E8 RID: 9960
	// (get) Token: 0x0601C9C6 RID: 117190 RVA: 0x008957F0 File Offset: 0x008939F0
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<AActor, SHotPatchGamepad> ActionMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<AActor, SHotPatchGamepad> result;
			if ((result = this._ActionMap) == null)
			{
				result = (this._ActionMap = new TMap<AActor, SHotPatchGamepad>(base.NativePtr + (IntPtr)TsHotPatchPanelConfig.__PropertyOffset_ActionMap, this));
			}
			return result;
		}
	}

	// Token: 0x170026E9 RID: 9961
	// (get) Token: 0x0601C9C7 RID: 117191 RVA: 0x0089582C File Offset: 0x00893A2C
	[UProperty(EPropertyFlags.CPF_None)]
	public TMap<AActor, string> AxisMap
	{
		get
		{
			base.FastCheckIsValid();
			TMap<AActor, string> result;
			if ((result = this._AxisMap) == null)
			{
				result = (this._AxisMap = new TMap<AActor, string>(base.NativePtr + (IntPtr)TsHotPatchPanelConfig.__PropertyOffset_AxisMap, this));
			}
			return result;
		}
	}

	// Token: 0x0601C9C8 RID: 117192 RVA: 0x00895868 File Offset: 0x00893A68
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void AwakeBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("AwakeBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601C9C9 RID: 117193 RVA: 0x008958D8 File Offset: 0x00893AD8
	protected virtual void AwakeBP_Implementation()
	{
		this.InputAction = delegate(bool bPress, string actionName)
		{
			List<UUIItem> list = this.RegisterActionMap[actionName];
			for (int i = 0; i < list.Count; i++)
			{
				UUIItem uuiitem = list[i];
				if (uuiitem.IsUIActiveInHierarchy())
				{
					AActor owner = uuiitem.GetOwner();
					UUIButtonComponent uuibuttonComponent = ((owner != null) ? owner.GetComponentByClass(UUIButtonComponent.StaticClass()) : null) as UUIButtonComponent;
					if (uuibuttonComponent == null || uuibuttonComponent.GetSelfInteractive())
					{
						Singleton<HotPatchEventSystem>.Instance.SimulationPointerDownUp(uuiitem, bPress);
					}
				}
			}
		};
		this.InputAxis = delegate(float value, string axisName)
		{
			List<UUIScrollViewWithScrollbarComponent> list = this.RegisterAxisMap[axisName];
			for (int i = 0; i < list.Count; i++)
			{
				UUIScrollViewWithScrollbarComponent uuiscrollViewWithScrollbarComponent = list[i];
				if (uuiscrollViewWithScrollbarComponent.RootUIComp.Get().IsUIActiveInHierarchy())
				{
					uuiscrollViewWithScrollbarComponent.SetVelocity(value * 800f);
				}
			}
		};
	}

	// Token: 0x0601C9CA RID: 117194 RVA: 0x00895900 File Offset: 0x00893B00
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnEnableBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnEnableBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601C9CB RID: 117195 RVA: 0x00895970 File Offset: 0x00893B70
	protected virtual void OnEnableBP_Implementation()
	{
		this.RegisterTextureMap();
		Singleton<HotPatchInputManager>.Instance.InsertPanelConfig(this);
	}

	// Token: 0x0601C9CC RID: 117196 RVA: 0x00895984 File Offset: 0x00893B84
	[UFunction(EFunctionFlags.FUNC_BlueprintNativeEvent)]
	public unsafe override void OnDisableBP()
	{
		int num;
		IntPtr ufunctionPtrAndSizeChecked = UnrealReflectionUtils.GetUFunctionPtrAndSizeChecked(base.NativePtr, new FName("OnDisableBP"), out num);
		byte* ptr = stackalloc byte[(UIntPtr)((num != 0) ? (num + 15) : 0)];
		byte* dest = null;
		if (num != 0)
		{
			dest = (ptr + 15L & -16L);
			UnrealReflectionUtils.InitializeStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
		UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, ufunctionPtrAndSizeChecked, null);
		if (num != 0)
		{
			UnrealReflectionUtils.DestroyStruct(ufunctionPtrAndSizeChecked, (void*)dest, 1);
		}
	}

	// Token: 0x0601C9CD RID: 117197 RVA: 0x008959F4 File Offset: 0x00893BF4
	protected virtual void OnDisableBP_Implementation()
	{
		Singleton<HotPatchInputManager>.Instance.RemovePanelConfig(this);
		this.UnRegisterTextureMap();
	}

	// Token: 0x0601C9CE RID: 117198 RVA: 0x00895A08 File Offset: 0x00893C08
	private void RegisterTextureMap()
	{
		this.TextureList = new List<ValueTuple<string, UUITexture>>();
		for (int i = 0; i < this.ActionMap.Num(); i++)
		{
			AActor key = this.ActionMap.GetKey(i);
			SHotPatchGamepad shotPatchGamepad = this.ActionMap.Get(key);
			if (!(shotPatchGamepad == null) && shotPatchGamepad.TextureActor != null && shotPatchGamepad.TextureActor.UITexture != null)
			{
				this.TextureList.Add(new ValueTuple<string, UUITexture>(shotPatchGamepad.ActionName, shotPatchGamepad.TextureActor.UITexture));
			}
		}
	}

	// Token: 0x0601C9CF RID: 117199 RVA: 0x00895A8F File Offset: 0x00893C8F
	private void UnRegisterTextureMap()
	{
		this.TextureList = new List<ValueTuple<string, UUITexture>>();
	}

	// Token: 0x0601C9D0 RID: 117200 RVA: 0x00895A9C File Offset: 0x00893C9C
	private void RegisterAction()
	{
		this.RegisterActionMap = new Dictionary<string, List<UUIItem>>();
		for (int i = 0; i < this.ActionMap.Num(); i++)
		{
			AActor key = this.ActionMap.GetKey(i);
			SHotPatchGamepad shotPatchGamepad = this.ActionMap.Get(key);
			if (!(shotPatchGamepad == null))
			{
				UUIItem uuiitem = key.GetComponentByClass(UUIItem.StaticClass()) as UUIItem;
				if (uuiitem != null)
				{
					List<UUIItem> list;
					if (!this.RegisterActionMap.TryGetValue(shotPatchGamepad.ActionName, out list))
					{
						list = new List<UUIItem>();
						this.RegisterActionMap[shotPatchGamepad.ActionName] = list;
						Singleton<HotPatchInputManager>.Instance.RegisterInputAction(shotPatchGamepad.ActionName, this.InputAction);
					}
					list.Add(uuiitem);
				}
			}
		}
	}

	// Token: 0x0601C9D1 RID: 117201 RVA: 0x00895B5C File Offset: 0x00893D5C
	private void RegisterAxis()
	{
		this.RegisterAxisMap = new Dictionary<string, List<UUIScrollViewWithScrollbarComponent>>();
		for (int i = 0; i < this.AxisMap.Num(); i++)
		{
			AActor key = this.AxisMap.GetKey(i);
			string text = this.AxisMap.Get(key);
			if (text != null)
			{
				UUIScrollViewWithScrollbarComponent uuiscrollViewWithScrollbarComponent = key.GetComponentByClass(UUIScrollViewWithScrollbarComponent.StaticClass()) as UUIScrollViewWithScrollbarComponent;
				if (uuiscrollViewWithScrollbarComponent != null)
				{
					List<UUIScrollViewWithScrollbarComponent> list;
					if (!this.RegisterAxisMap.TryGetValue(text, out list))
					{
						list = new List<UUIScrollViewWithScrollbarComponent>();
						this.RegisterAxisMap[text] = list;
						Singleton<HotPatchInputManager>.Instance.RegisterInputAxis(text, this.InputAxis);
					}
					list.Add(uuiscrollViewWithScrollbarComponent);
				}
			}
		}
	}

	// Token: 0x0601C9D2 RID: 117202 RVA: 0x00895C04 File Offset: 0x00893E04
	private void UnRegisterAction()
	{
		if (this.RegisterActionMap == null)
		{
			return;
		}
		foreach (string actionName in this.RegisterActionMap.Keys)
		{
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction(actionName, this.InputAction);
		}
		this.RegisterActionMap.Clear();
	}

	// Token: 0x0601C9D3 RID: 117203 RVA: 0x00895C7C File Offset: 0x00893E7C
	private void UnRegisterAxis()
	{
		if (this.RegisterAxisMap == null)
		{
			return;
		}
		foreach (string axisName in this.RegisterAxisMap.Keys)
		{
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAxis(axisName, this.InputAxis);
		}
		this.RegisterAxisMap.Clear();
	}

	// Token: 0x0601C9D4 RID: 117204 RVA: 0x00895CF4 File Offset: 0x00893EF4
	public void RegisterActionAndAxis()
	{
		this.RegisterAction();
		this.RegisterAxis();
	}

	// Token: 0x0601C9D5 RID: 117205 RVA: 0x00895D02 File Offset: 0x00893F02
	public void UnRegisterActionAndAxis()
	{
		this.UnRegisterAction();
		this.UnRegisterAxis();
	}

	// Token: 0x0601C9D6 RID: 117206 RVA: 0x00895D10 File Offset: 0x00893F10
	public void RefreshTexture()
	{
		for (int i = 0; i < this.TextureList.Count; i++)
		{
			ValueTuple<string, UUITexture> valueTuple = this.TextureList[i];
			if (!Singleton<InputDevice>.Instance.IsInGamepad())
			{
				valueTuple.Item2.SetUIActive(false);
			}
			else
			{
				UTexture textureByActionName = Singleton<HotPatchInputManager>.Instance.GetTextureByActionName(valueTuple.Item1);
				if (textureByActionName != null)
				{
					valueTuple.Item2.SetUIActive(true);
					valueTuple.Item2.SetTexture(textureByActionName);
					valueTuple.Item2.SetSizeFromTexture();
				}
			}
		}
	}

	// Token: 0x0601C9D7 RID: 117207 RVA: 0x00895D94 File Offset: 0x00893F94
	public void HideTexture()
	{
		for (int i = 0; i < this.TextureList.Count; i++)
		{
			this.TextureList[i].Item2.SetUIActive(false);
		}
	}

	// Token: 0x0601C9D8 RID: 117208 RVA: 0x00895DCE File Offset: 0x00893FCE
	public new static UClassStackOnlyPtr StaticClass()
	{
		if (TsHotPatchPanelConfig._ClassPtr == IntPtr.Zero)
		{
			UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Launcher/PlayerInput/TsHotPatchPanelConfig.TsHotPatchPanelConfig_C");
		}
		return TsHotPatchPanelConfig._ClassPtr;
	}

	// Token: 0x0601C9D9 RID: 117209 RVA: 0x00895DF4 File Offset: 0x00893FF4
	public TsHotPatchPanelConfig() : this(BuiltinUtils.AllocNativeUObject(TsHotPatchPanelConfig.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
	{
	}

	// Token: 0x0601C9DA RID: 117210 RVA: 0x00895E1C File Offset: 0x0089401C
	public TsHotPatchPanelConfig(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(TsHotPatchPanelConfig.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
	{
	}

	// Token: 0x0601C9DB RID: 117211 RVA: 0x00895E4F File Offset: 0x0089404F
	protected TsHotPatchPanelConfig(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
	{
	}

	// Token: 0x0601C9DC RID: 117212 RVA: 0x00895E58 File Offset: 0x00894058
	protected virtual void __CPPCALL_AwakeBP_Implementation()
	{
		this.AwakeBP_Implementation();
	}

	// Token: 0x0601C9DD RID: 117213 RVA: 0x00895E60 File Offset: 0x00894060
	protected virtual void __CPPCALL_OnEnableBP_Implementation()
	{
		this.OnEnableBP_Implementation();
	}

	// Token: 0x0601C9DE RID: 117214 RVA: 0x00895E68 File Offset: 0x00894068
	protected virtual void __CPPCALL_OnDisableBP_Implementation()
	{
		this.OnDisableBP_Implementation();
	}

	// Token: 0x0400E66C RID: 58988
	private TInputAction InputAction;

	// Token: 0x0400E66D RID: 58989
	private TInputAxis InputAxis;

	// Token: 0x0400E66E RID: 58990
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<string, List<UUIItem>> RegisterActionMap;

	// Token: 0x0400E66F RID: 58991
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Dictionary<string, List<UUIScrollViewWithScrollbarComponent>> RegisterAxisMap;

	// Token: 0x0400E670 RID: 58992
	[Nullable(new byte[]
	{
		2,
		0,
		1,
		1
	})]
	private List<ValueTuple<string, UUITexture>> TextureList;

	// Token: 0x0400E671 RID: 58993
	public new const string __ObjectPath = "/Game/Aki/TypeScript/Launcher/PlayerInput/TsHotPatchPanelConfig.TsHotPatchPanelConfig_C";

	// Token: 0x0400E672 RID: 58994
	private static IntPtr _ClassPtr;

	// Token: 0x0400E673 RID: 58995
	private static IntPtr _ClassDefaultObjectPtr;

	// Token: 0x0400E674 RID: 58996
	private static int __PropertyOffset_ActionMap;

	// Token: 0x0400E675 RID: 58997
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<AActor, SHotPatchGamepad> _ActionMap;

	// Token: 0x0400E676 RID: 58998
	private static int __PropertyOffset_AxisMap;

	// Token: 0x0400E677 RID: 58999
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private TMap<AActor, string> _AxisMap;
}
