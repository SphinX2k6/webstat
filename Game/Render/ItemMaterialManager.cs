using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Render
{
	// Token: 0x02004793 RID: 18323
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ItemMaterialManager : Singleton<ItemMaterialManager>
	{
		// Token: 0x0602F8C1 RID: 194753 RVA: 0x00B541D8 File Offset: 0x00B523D8
		public void Initialize()
		{
			this.GlobalController = null;
			this.ActorControllers = new List<ItemMaterialActorController>();
			this.IndexCountGlobal = -1;
			this.IndexCount = -1;
			this.AllGlobalControllerInfoMap = new Dictionary<int, ItemMaterialGlobalController>();
			this.AllActorControllerInfoMap = new Dictionary<int, ItemMaterialActorController>();
			this.IsInit = true;
		}

		// Token: 0x0602F8C2 RID: 194754 RVA: 0x00B54218 File Offset: 0x00B52418
		public void Tick(float delta)
		{
			RenderStats.Init();
			float deltaSecond = delta * 0.001f;
			List<int> list = new List<int>();
			if (!this.IsInit)
			{
				this.Initialize();
			}
			if (this.AllGlobalControllerInfoMap.Count > 0)
			{
				foreach (KeyValuePair<int, ItemMaterialGlobalController> keyValuePair in this.AllGlobalControllerInfoMap)
				{
					int num;
					ItemMaterialGlobalController itemMaterialGlobalController;
					keyValuePair.Deconstruct(out num, out itemMaterialGlobalController);
					int key = num;
					ItemMaterialGlobalController itemMaterialGlobalController2 = itemMaterialGlobalController;
					if (itemMaterialGlobalController2.IsValid())
					{
						itemMaterialGlobalController2.Update(deltaSecond);
					}
					else
					{
						itemMaterialGlobalController2.Destroy();
						this.AllGlobalControllerInfoMap.Remove(key);
					}
				}
			}
			if (this.AllActorControllerInfoMap.Count > 0)
			{
				foreach (KeyValuePair<int, ItemMaterialActorController> keyValuePair2 in this.AllActorControllerInfoMap)
				{
					int num;
					ItemMaterialActorController itemMaterialActorController;
					keyValuePair2.Deconstruct(out num, out itemMaterialActorController);
					int item = num;
					ItemMaterialActorController itemMaterialActorController2 = itemMaterialActorController;
					if (itemMaterialActorController2.IsValid() && itemMaterialActorController2.GetLifeTimeController() != null)
					{
						itemMaterialActorController2.Update(deltaSecond);
					}
					else
					{
						list.Add(item);
					}
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				int num2 = list[i];
				ItemMaterialActorController itemMaterialActorController3;
				if (this.AllActorControllerInfoMap.Remove(num2, out itemMaterialActorController3))
				{
					itemMaterialActorController3.Destroy();
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RenderEffect;
					ELogAuthor author = ELogAuthor.LJY;
					string message = "单体交互物材质控制器队列已经没有目标控制器，卸载失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", num2);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				ItemMaterialDataMap dataMap = this.DataMap;
				if (dataMap == null || !dataMap.IsValid())
				{
					return;
				}
				ItemMaterialDataMap dataMap2 = this.DataMap;
				if (dataMap2 != null)
				{
					dataMap2.Map.Remove((float)num2);
				}
			}
			if (this.AllMaterialSimpleControllers.Count > 0)
			{
				foreach (KeyValuePair<int, ItemMaterialSimpleController> keyValuePair3 in this.AllMaterialSimpleControllers)
				{
					int num;
					ItemMaterialSimpleController itemMaterialSimpleController;
					keyValuePair3.Deconstruct(out num, out itemMaterialSimpleController);
					itemMaterialSimpleController.UpdateParameters();
				}
			}
		}

		// Token: 0x0602F8C3 RID: 194755 RVA: 0x00B5444C File Offset: 0x00B5264C
		[NullableContext(2)]
		public int AddMaterialData(AActor actor, ItemMaterialControllerActorData materialData)
		{
			if (actor == null || !actor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.LJY;
				string message = "想要添加单体交互物材质控制器，但是传入的Actor是无效的";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", actor);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return -1;
			}
			if (materialData == null || !materialData.IsValid())
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RenderEffect;
				ELogAuthor author2 = ELogAuthor.LJY;
				string message2 = "想要添加单体交互物材质控制器，但是传入的Data是无效的";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Actor", actor);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return -1;
			}
			ItemMaterialDataMap dataMap = this.DataMap;
			if (dataMap == null || !dataMap.IsValid())
			{
				this.DataMap = (Singleton<ActorSystem>.Instance.Get(ItemMaterialDataMap.StaticClass(), FTransformDouble.Identity, null, true) as ItemMaterialDataMap);
				this.DataMap.Map.Empty(0);
			}
			this.IndexCount++;
			int indexCount = this.IndexCount;
			ItemMaterialControllerActorData itemMaterialControllerActorData;
			if (!this.DataMap.Map.TryGetValue((float)indexCount, out itemMaterialControllerActorData) || !itemMaterialControllerActorData.IsValid())
			{
				this.DataMap.Map[(float)indexCount] = materialData;
				this.AllActorControllerInfoMap[indexCount] = new ItemMaterialActorController(actor, materialData);
				return indexCount;
			}
			return -1;
		}

		// Token: 0x0602F8C4 RID: 194756 RVA: 0x00B54574 File Offset: 0x00B52774
		public bool DisableActorData(int handle)
		{
			if (this.AllActorControllerInfoMap == null)
			{
				return false;
			}
			ItemMaterialActorController itemMaterialActorController;
			if (!this.AllActorControllerInfoMap.TryGetValue(handle, out itemMaterialActorController))
			{
				return false;
			}
			if (itemMaterialActorController != null)
			{
				itemMaterialActorController.Stop(false);
				return true;
			}
			return false;
		}

		// Token: 0x0602F8C5 RID: 194757 RVA: 0x00B545AC File Offset: 0x00B527AC
		public bool DisableAllActorData()
		{
			if (this.AllActorControllerInfoMap == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.LJY;
				string message = "不满足删除单体交互物材质控制器的条件，返回false";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("handle", -1);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			foreach (KeyValuePair<int, ItemMaterialActorController> keyValuePair in this.AllActorControllerInfoMap)
			{
				int num;
				ItemMaterialActorController itemMaterialActorController;
				keyValuePair.Deconstruct(out num, out itemMaterialActorController);
				int item = num;
				itemMaterialActorController.Stop(false);
				this.WaitList.Add(item);
			}
			ItemMaterialDataMap dataMap = this.DataMap;
			if (dataMap == null || !dataMap.IsValid())
			{
				return false;
			}
			ItemMaterialDataMap dataMap2 = this.DataMap;
			if (dataMap2 != null)
			{
				dataMap2.Map.Empty(0);
			}
			this.IndexCount = -1;
			return true;
		}

		// Token: 0x0602F8C6 RID: 194758 RVA: 0x00B54688 File Offset: 0x00B52888
		public int AddSimpleMaterialController([Nullable(2)] AActor actor, Dictionary<FName, float> scalarParameterValue, Dictionary<FName, FLinearColor> vectorParameterValue)
		{
			if (actor == null || !actor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RenderEffect;
				ELogAuthor author = ELogAuthor.LJY;
				string message = "想要添加单体交互物材质控制器，但是传入的Actor是无效的";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Actor", actor);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return -1;
			}
			int num3;
			foreach (KeyValuePair<int, ItemMaterialSimpleController> keyValuePair in this.AllMaterialSimpleControllers)
			{
				int num;
				ItemMaterialSimpleController itemMaterialSimpleController;
				keyValuePair.Deconstruct(out num, out itemMaterialSimpleController);
				int num2 = num;
				ItemMaterialSimpleController itemMaterialSimpleController2 = itemMaterialSimpleController;
				if (itemMaterialSimpleController2.GetActor() == actor)
				{
					num3 = num2;
					itemMaterialSimpleController2.ScalarParameterValue = scalarParameterValue;
					itemMaterialSimpleController2.VectorParameterValue = vectorParameterValue;
					return num3;
				}
			}
			this.IndexCountSimple++;
			num3 = this.IndexCountSimple;
			ItemMaterialSimpleController itemMaterialSimpleController3 = new ItemMaterialSimpleController(actor);
			itemMaterialSimpleController3.ScalarParameterValue = scalarParameterValue;
			itemMaterialSimpleController3.VectorParameterValue = vectorParameterValue;
			this.AllMaterialSimpleControllers[num3] = itemMaterialSimpleController3;
			return num3;
		}

		// Token: 0x0602F8C7 RID: 194759 RVA: 0x00B54784 File Offset: 0x00B52984
		public bool DisableSimpleMaterialController(int handle)
		{
			if (this.AllMaterialSimpleControllers == null)
			{
				return false;
			}
			this.AllMaterialSimpleControllers.Remove(handle);
			return true;
		}

		// Token: 0x0401B316 RID: 111382
		[Nullable(2)]
		protected ItemMaterialGlobalController GlobalController;

		// Token: 0x0401B317 RID: 111383
		protected List<ItemMaterialActorController> ActorControllers = new List<ItemMaterialActorController>();

		// Token: 0x0401B318 RID: 111384
		public Dictionary<int, ItemMaterialGlobalController> AllGlobalControllerInfoMap = new Dictionary<int, ItemMaterialGlobalController>();

		// Token: 0x0401B319 RID: 111385
		public Dictionary<int, ItemMaterialActorController> AllActorControllerInfoMap = new Dictionary<int, ItemMaterialActorController>();

		// Token: 0x0401B31A RID: 111386
		public Dictionary<int, ItemMaterialSimpleController> AllMaterialSimpleControllers = new Dictionary<int, ItemMaterialSimpleController>();

		// Token: 0x0401B31B RID: 111387
		public int IndexCountGlobal = -1;

		// Token: 0x0401B31C RID: 111388
		public int IndexCount = -1;

		// Token: 0x0401B31D RID: 111389
		public int IndexCountSimple = -1;

		// Token: 0x0401B31E RID: 111390
		public readonly int RefErrorCount = 5;

		// Token: 0x0401B31F RID: 111391
		[Nullable(2)]
		public ItemMaterialDataMap DataMap;

		// Token: 0x0401B320 RID: 111392
		public bool IsInit;

		// Token: 0x0401B321 RID: 111393
		public List<int> WaitList = new List<int>();
	}
}
