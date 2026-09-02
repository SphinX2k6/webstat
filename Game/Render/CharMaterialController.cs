using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.Components;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialContainer;
using AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004756 RID: 18262
	[NullableContext(1)]
	[Nullable(0)]
	public class CharMaterialController : CharRenderBase
	{
		// Token: 0x0602F679 RID: 194169 RVA: 0x00B41800 File Offset: 0x00B3FA00
		public unsafe void PrintCurrentInfo()
		{
			string text = string.Empty;
			foreach (CharMaterialControlRuntimeData charMaterialControlRuntimeData in this.AllMaterialControlRuntimeDataMap.Values)
			{
				text = text + "[" + charMaterialControlRuntimeData.DataCache.Data.GetName() + "]   ";
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.RenderCharacter;
			ELogAuthor author = ELogAuthor.ZJF;
			string empty = string.Empty;
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("当前存在的角色特效DA", text);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Actor", this.OwnerActorName);
			instance.Info(module, author, empty, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}

		// Token: 0x0602F67A RID: 194170 RVA: 0x00B418D0 File Offset: 0x00B3FAD0
		public override void Start()
		{
			base.Start();
			this.TempRemoveList.Clear();
			this.RuntimeDataIdGenerator = 0;
			this.EnableDebug = false;
			this.DebugInfo = new PD_MaterialDebug_C();
			this.AllMaterialControlRuntimeDataMap = new Dictionary<int, CharMaterialControlRuntimeData>();
			this.OwnerActorName = base.GetRenderingComponent().GetOwner().GetName();
			CharRenderBase component = this.RenderComponent.GetComponent(1);
			if (component == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "材质控制器初始化失败，不存在CharMaterialContainer";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", this.OwnerActorName);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			this.MaterialContainer = (CharMaterialContainer)component;
			CharRenderBase component2 = this.RenderComponent.GetComponent(12);
			this.ExtraMesh = (CharExtraMesh)component2;
			string name = "Render_CharMaterialControllerTick_" + this.OwnerActorName;
			this.StatMaterialControllerTick = Stat.CreateNoFlameGraph(name, "", "");
			base.OnInitSuccess();
		}

		// Token: 0x0602F67B RID: 194171 RVA: 0x00B419B8 File Offset: 0x00B3FBB8
		public bool GetRuntimeMaterialControllerValid(int id)
		{
			return this.AllMaterialControlRuntimeDataMap.ContainsKey(id);
		}

		// Token: 0x0602F67C RID: 194172 RVA: 0x00B419C8 File Offset: 0x00B3FBC8
		public unsafe override void Update()
		{
			foreach (CharMaterialControlRuntimeData charMaterialControlRuntimeData in this.AllMaterialControlRuntimeDataMap.Values)
			{
				LogicalTimeDilationOut outVal = new LogicalTimeDilationOut
				{
					LogicalTimeDilation = 1f
				};
				float timeDilation = base.GetRenderingComponent().GetTimeDilation(outVal);
				double delta = Singleton<Time>.Instance.NowSeconds - charMaterialControlRuntimeData.LastUpdateTime;
				charMaterialControlRuntimeData.LastUpdateTime = Singleton<Time>.Instance.NowSeconds;
				charMaterialControlRuntimeData.UpdateState(delta, timeDilation);
				charMaterialControlRuntimeData.UpdateEffect(this.MaterialContainer);
				if (charMaterialControlRuntimeData.IsDead)
				{
					this.TempRemoveList.Add(charMaterialControlRuntimeData.Id);
				}
			}
			if (this.EnableDebug && this.DebugInfo != null)
			{
				this.DebugInfo.MaterialControllerList.Empty(0);
				foreach (KeyValuePair<int, CharMaterialControlRuntimeData> keyValuePair in this.AllMaterialControlRuntimeDataMap)
				{
					this.DebugInfo.MaterialControllerList.Add(keyValuePair.Key, keyValuePair.Value.DataCache.DataName);
				}
			}
			if (this.TempRemoveList.Count > 0)
			{
				foreach (int num in this.TempRemoveList)
				{
					CharMaterialControlRuntimeData charMaterialControlRuntimeData2;
					if (!this.AllMaterialControlRuntimeDataMap.TryGetValue(num, out charMaterialControlRuntimeData2))
					{
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.RenderCharacter;
						ELogAuthor author = ELogAuthor.LSY;
						string message = "材质控制器句柄重复移除";
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", this.OwnerActorName);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handle", num);
						instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
					else
					{
						charMaterialControlRuntimeData2.Destroy();
						this.AllMaterialControlRuntimeDataMap.Remove(num);
						Singleton<EventSystem>.Instance.EmitWithTarget<int>(this.RenderComponent, EEventName.OnRemoveMaterialController, num);
					}
				}
				this.TempRemoveList.Clear();
				this.UpdateRuntimeDataEffectState();
			}
		}

		// Token: 0x0602F67D RID: 194173 RVA: 0x00B41C18 File Offset: 0x00B3FE18
		public void SetEffectProgress(float progress, int handleId)
		{
			CharMaterialControlRuntimeData charMaterialControlRuntimeData;
			if (this.AllMaterialControlRuntimeDataMap.TryGetValue(handleId, out charMaterialControlRuntimeData))
			{
				charMaterialControlRuntimeData.SetProgress(progress);
			}
		}

		// Token: 0x0602F67E RID: 194174 RVA: 0x00B41C3C File Offset: 0x00B3FE3C
		public override void Destroy()
		{
			foreach (CharMaterialControlRuntimeData charMaterialControlRuntimeData in this.AllMaterialControlRuntimeDataMap.Values)
			{
				charMaterialControlRuntimeData.Destroy();
			}
			this.AllMaterialControlRuntimeDataMap = new Dictionary<int, CharMaterialControlRuntimeData>();
		}

		// Token: 0x0602F67F RID: 194175 RVA: 0x00B41C9C File Offset: 0x00B3FE9C
		public unsafe void RemoveSkeletalMeshMaterialControllerData(string skelName)
		{
			foreach (CharMaterialControlRuntimeData charMaterialControlRuntimeData in this.AllMaterialControlRuntimeDataMap.Values)
			{
				if (charMaterialControlRuntimeData.SpecifiedMaterialIndexMap != null)
				{
					charMaterialControlRuntimeData.SpecifiedMaterialIndexMap.Remove(skelName);
				}
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "移除材质控制器部件";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("SkelName", skelName);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("handleId", charMaterialControlRuntimeData.Id);
				instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
		}

		// Token: 0x0602F680 RID: 194176 RVA: 0x00B41D64 File Offset: 0x00B3FF64
		public override void OnResetRenderState()
		{
			if (this.AllMaterialControlRuntimeDataMap.Count > 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.ZJF;
				string message = "移除全部材质控制器";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", base.GetRenderingComponent().GetOwner());
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			foreach (CharMaterialControlRuntimeData charMaterialControlRuntimeData in this.AllMaterialControlRuntimeDataMap.Values)
			{
				charMaterialControlRuntimeData.IsDead = true;
				charMaterialControlRuntimeData.UpdateEffect(this.MaterialContainer);
				charMaterialControlRuntimeData.Destroy();
			}
			this.AllMaterialControlRuntimeDataMap.Clear();
		}

		// Token: 0x0602F681 RID: 194177 RVA: 0x00B41E18 File Offset: 0x00B40018
		public bool RemoveMaterialControllerData(int handle)
		{
			CharMaterialControlRuntimeData charMaterialControlRuntimeData;
			if (!this.AllMaterialControlRuntimeDataMap.TryGetValue(handle, out charMaterialControlRuntimeData))
			{
				return false;
			}
			base.GetRenderingComponent().GetOwner().GetName();
			charMaterialControlRuntimeData.IsDead = true;
			charMaterialControlRuntimeData.UpdateEffect(this.MaterialContainer);
			charMaterialControlRuntimeData.Destroy();
			this.AllMaterialControlRuntimeDataMap.Remove(handle);
			this.UpdateRuntimeDataEffectState();
			return true;
		}

		// Token: 0x0602F682 RID: 194178 RVA: 0x00B41E78 File Offset: 0x00B40078
		public bool RemoveMaterialControllerDataWithEnding(int handle)
		{
			CharMaterialControlRuntimeData charMaterialControlRuntimeData;
			if (!this.AllMaterialControlRuntimeDataMap.TryGetValue(handle, out charMaterialControlRuntimeData))
			{
				return false;
			}
			base.GetRenderingComponent().GetOwner().GetName();
			charMaterialControlRuntimeData.SetReadyToDie();
			return true;
		}

		// Token: 0x0602F683 RID: 194179 RVA: 0x00B41EB0 File Offset: 0x00B400B0
		[NullableContext(2)]
		public unsafe int AddMaterialControllerData(PD_CharacterControllerData_C data, UObject userData = null)
		{
			if (data == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.MY;
				string message = "添加的材质控制器数据为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", base.GetRenderingComponent().GetOwner());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return -1;
			}
			if (this.AllMaterialControlRuntimeDataMap.Keys.Count > 20)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.MY;
				string message2 = "材质控制器添加失败，超过单个角色的材质控制器队列数量，检查是否进行了材质控制器移除和材质控制器特效的持续时间";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", base.GetRenderingComponent().GetOwner());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("添加的材质控制器名称", data);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			this.RuntimeDataIdGenerator++;
			int runtimeDataIdGenerator = this.RuntimeDataIdGenerator;
			if (!this.DealWithExtraMesh(data, runtimeDataIdGenerator))
			{
				return -1;
			}
			CharMaterialControlRuntimeData charMaterialControlRuntimeData = new CharMaterialControlRuntimeData();
			charMaterialControlRuntimeData.Init(runtimeDataIdGenerator, data, userData);
			charMaterialControlRuntimeData.SetSpecifiedMaterialIndex(this.MaterialContainer);
			this.AllMaterialControlRuntimeDataMap.Add(runtimeDataIdGenerator, charMaterialControlRuntimeData);
			this.UpdateRuntimeDataEffectState();
			this.MaterialContainer.MarkForceUpdateThisFrame();
			return runtimeDataIdGenerator;
		}

		// Token: 0x0602F684 RID: 194180 RVA: 0x00B41FC0 File Offset: 0x00B401C0
		private void UpdateRuntimeDataEffectState()
		{
			List<CharMaterialControlRuntimeData> list = new List<CharMaterialControlRuntimeData>(this.AllMaterialControlRuntimeDataMap.Values);
			bool flag = false;
			list.Reverse();
			foreach (CharMaterialControlRuntimeData charMaterialControlRuntimeData in list)
			{
				if (flag)
				{
					charMaterialControlRuntimeData.RequestEffectStateRevert();
				}
				else
				{
					charMaterialControlRuntimeData.RequestEffectStateEnter();
				}
				if (charMaterialControlRuntimeData.DataCache.MaskOriginEffect)
				{
					flag = true;
				}
			}
		}

		// Token: 0x0602F685 RID: 194181 RVA: 0x00B42040 File Offset: 0x00B40240
		public bool AddMaterialControllerDataDestroyCallback(int handle, Action<int> callback)
		{
			CharMaterialControlRuntimeData charMaterialControlRuntimeData;
			if (!this.AllMaterialControlRuntimeDataMap.TryGetValue(handle, out charMaterialControlRuntimeData))
			{
				return false;
			}
			base.GetRenderingComponent().GetOwner();
			return charMaterialControlRuntimeData.AddDestroyCallback(callback);
		}

		// Token: 0x0602F686 RID: 194182 RVA: 0x00B42074 File Offset: 0x00B40274
		public bool RemoveMaterialControllerDataDestroyCallback(int handle, Action<int> callback)
		{
			CharMaterialControlRuntimeData charMaterialControlRuntimeData;
			if (!this.AllMaterialControlRuntimeDataMap.TryGetValue(handle, out charMaterialControlRuntimeData))
			{
				return false;
			}
			base.GetRenderingComponent().GetOwner().GetName();
			return charMaterialControlRuntimeData.RemoveDestroyCallback(callback);
		}

		// Token: 0x0602F687 RID: 194183 RVA: 0x00B420AC File Offset: 0x00B402AC
		protected unsafe bool DealWithExtraMesh(PD_CharacterControllerData_C data, int handle)
		{
			if (data.SpecifiedBodyType != ECharacterBodySpecifiedType.ExtraBody)
			{
				return true;
			}
			if (this.ExtraMesh == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderCharacter;
				ELogAuthor author = ELogAuthor.LSY;
				string message = "材质控制器添加失败，ExtraMesh不存在";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Actor", base.GetRenderingComponent().GetOwner());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("添加的材质控制器名称", data);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			if (data.MaterialModifyType != ECharacterControllerApplyType.ReplaceMaterial)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderCharacter;
				ELogAuthor author2 = ELogAuthor.LSY;
				string message2 = "材质控制器添加失败，ExtraMesh只支持材质替换";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("Actor", base.GetRenderingComponent().GetOwner());
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("添加的材质控制器名称", data);
				instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				return false;
			}
			if (data.SpecifiedBodyType == ECharacterBodySpecifiedType.ExtraBody)
			{
				string[] bodyNamesByBodyType = RenderConfig.GetBodyNamesByBodyType(ECharacterBodySpecifiedType.Body);
				string bodyName = bodyNamesByBodyType[0];
				this.ExtraMesh.EnsureExtraMesh(bodyName);
				this.ExtraMesh.AddExtraSkeletalMeshUsage(bodyName);
				this.AddMaterialControllerDataDestroyCallback(handle, delegate(int _)
				{
					CharExtraMesh extraMesh = this.ExtraMesh;
					if (extraMesh == null)
					{
						return;
					}
					extraMesh.RemoveExtraSkeletalMeshUsage(bodyName);
				});
				return true;
			}
			return false;
		}

		// Token: 0x0602F688 RID: 194184 RVA: 0x00B4220D File Offset: 0x00B4040D
		public override int GetComponentId()
		{
			return 2;
		}

		// Token: 0x0602F689 RID: 194185 RVA: 0x00B42210 File Offset: 0x00B40410
		public override string GetStatName()
		{
			return "CharMaterialController";
		}

		// Token: 0x0401AFDA RID: 110554
		[Nullable(2)]
		public CharMaterialContainer MaterialContainer;

		// Token: 0x0401AFDB RID: 110555
		[Nullable(2)]
		public CharExtraMesh ExtraMesh;

		// Token: 0x0401AFDC RID: 110556
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Dictionary<int, CharMaterialControlRuntimeData> AllMaterialControlRuntimeDataMap;

		// Token: 0x0401AFDD RID: 110557
		private int RuntimeDataIdGenerator;

		// Token: 0x0401AFDE RID: 110558
		private readonly List<int> TempRemoveList = new List<int>();

		// Token: 0x0401AFDF RID: 110559
		private string OwnerActorName = string.Empty;

		// Token: 0x0401AFE0 RID: 110560
		public bool EnableDebug;

		// Token: 0x0401AFE1 RID: 110561
		[Nullable(2)]
		public PD_MaterialDebug_C DebugInfo;

		// Token: 0x0401AFE2 RID: 110562
		[Nullable(2)]
		private Stat StatMaterialControllerTick;
	}
}
