using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Common.Component
{
	// Token: 0x020048B9 RID: 18617
	[NullableContext(1)]
	[Nullable(0)]
	public class BaseOutlookComponent : EntityComponent
	{
		// Token: 0x0603089C RID: 198812 RVA: 0x00BEB674 File Offset: 0x00BE9874
		protected override bool OnClear()
		{
			foreach (KeyValuePair<int, DecorationItem> keyValuePair in this.AllDecoration)
			{
				DecorationItem value = keyValuePair.Value;
				if (value != null)
				{
					value.Clear();
				}
			}
			this.AllDecoration.Clear();
			this.CurrentDecoration.Clear();
			return true;
		}

		// Token: 0x0603089D RID: 198813 RVA: 0x00BEB6EC File Offset: 0x00BE98EC
		protected override void OnEnable()
		{
			this.RefreshDecorationVisibility("BaseOutlookComponent.OnEnable");
		}

		// Token: 0x0603089E RID: 198814 RVA: 0x00BEB6F9 File Offset: 0x00BE98F9
		protected override void OnDisable(string reason)
		{
			this.RefreshDecorationVisibility("BaseOutlookComponent.OnDisable");
		}

		// Token: 0x0603089F RID: 198815 RVA: 0x00BEB708 File Offset: 0x00BE9908
		public void RefreshDecorationVisibility(string reason)
		{
			foreach (DecorationItem decorationItem in this.AllDecoration.Values)
			{
				if (decorationItem != null)
				{
					decorationItem.RefreshVisibility(reason, true);
				}
			}
		}

		// Token: 0x060308A0 RID: 198816 RVA: 0x00BEB768 File Offset: 0x00BE9968
		protected DecorationItem CreateDecorationItem(USkeletalMeshComponent parentMesh, int index, bool alwaysUpdate = false, bool needDelayShow = false)
		{
			return this.CreateDecorationPair(parentMesh, index, alwaysUpdate, needDelayShow).Item2;
		}

		// Token: 0x060308A1 RID: 198817 RVA: 0x00BEB77C File Offset: 0x00BE997C
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		protected ValueTuple<int, DecorationItem> CreateDecorationPair(USkeletalMeshComponent parentMesh, int index, bool alwaysUpdate = false, bool needDelayShow = false)
		{
			DecorationItem decorationItem = new DecorationItem(this, parentMesh, index, alwaysUpdate, needDelayShow);
			this.AddRenderMesh(decorationItem);
			int num = this.DecorationUid + 1;
			this.DecorationUid = num;
			int num2 = num;
			this.AllDecoration[num2] = decorationItem;
			return new ValueTuple<int, DecorationItem>(num2, decorationItem);
		}

		// Token: 0x060308A2 RID: 198818 RVA: 0x00BEB7C2 File Offset: 0x00BE99C2
		protected virtual void AddRenderMesh(DecorationItem item)
		{
		}

		// Token: 0x060308A3 RID: 198819 RVA: 0x00BEB7C4 File Offset: 0x00BE99C4
		protected virtual int? GetDecorationModelId(int decorationId)
		{
			return null;
		}

		// Token: 0x060308A4 RID: 198820 RVA: 0x00BEB7DC File Offset: 0x00BE99DC
		[NullableContext(2)]
		public unsafe void EquipDecoration(List<int> decorationIds)
		{
			List<int> list = decorationIds ?? new List<int>();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Decoration;
			ELogAuthor author = ELogAuthor.LCZ;
			string message = "[Decoration] Equip Decorations";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("length", list.Count);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			if (this.SkelMeshComp == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Decoration, ELogAuthor.LCZ, "[Decoration] No Mesh to Equip.", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			for (int i = 0; i < list.Count; i++)
			{
				DecorationItem decorationItem = null;
				if (!this.CurrentDecoration.ContainsKey(i))
				{
					ValueTuple<int, DecorationItem> valueTuple = this.CreateDecorationPair(this.SkelMeshComp, i, false, false);
					this.CurrentDecoration[i] = valueTuple.Item1;
					decorationItem = valueTuple.Item2;
				}
				else
				{
					int key = this.CurrentDecoration[i];
					this.AllDecoration.TryGetValue(key, out decorationItem);
				}
				if (decorationItem != null)
				{
					int num = list[i];
					if (num == 0)
					{
						decorationItem.SetDecorationId(0);
					}
					else
					{
						int? decorationModelId = this.GetDecorationModelId(num);
						if (decorationModelId == null)
						{
							Log instance2 = Singleton<Log>.Instance;
							ELogModule module2 = ELogModule.Decoration;
							ELogAuthor author2 = ELogAuthor.LCZ;
							string message2 = "[Decoration] Equip Decoration Error. 缺失Excel配置";
							<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("EntityId", base.Entity.Id);
							*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("Id", num);
							instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
							decorationItem.SetDecorationId(0);
						}
						else
						{
							decorationItem.SetDecorationId(decorationModelId.Value);
						}
					}
				}
			}
			int count = this.CurrentDecoration.Count;
			for (int j = list.Count; j < count; j++)
			{
				int key2;
				if (this.CurrentDecoration.TryGetValue(j, out key2))
				{
					DecorationItem decorationItem2;
					if (this.AllDecoration.TryGetValue(key2, out decorationItem2) && decorationItem2 != null)
					{
						decorationItem2.Clear();
					}
					this.AllDecoration.Remove(key2);
				}
				this.CurrentDecoration.Remove(j);
			}
		}

		// Token: 0x060308A5 RID: 198821 RVA: 0x00BEBA2C File Offset: 0x00BE9C2C
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			BaseOutlookComponent baseOutlookComponent = (BaseOutlookComponent)componentTemplate;
			if (base.CanResetComponentProperty("DecorationUid"))
			{
				this.DecorationUid = baseOutlookComponent.DecorationUid;
			}
			if (base.CanResetComponentProperty("SkelMeshComp"))
			{
				if (baseOutlookComponent.SkelMeshComp == null)
				{
					this.SkelMeshComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<USkeletalMeshComponent>(this.SkelMeshComp), "SkelMeshComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AllDecoration"))
			{
				if (baseOutlookComponent.AllDecoration == null)
				{
					this.AllDecoration = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, DecorationItem>>(this.AllDecoration), "AllDecoration"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CurrentDecoration"))
			{
				if (baseOutlookComponent.CurrentDecoration == null)
				{
					this.CurrentDecoration = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<Dictionary<int, int>>(this.CurrentDecoration), "CurrentDecoration"))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0401BE55 RID: 114261
		private int DecorationUid;

		// Token: 0x0401BE56 RID: 114262
		[Nullable(2)]
		protected USkeletalMeshComponent SkelMeshComp;

		// Token: 0x0401BE57 RID: 114263
		protected Dictionary<int, DecorationItem> AllDecoration = new Dictionary<int, DecorationItem>();

		// Token: 0x0401BE58 RID: 114264
		protected Dictionary<int, int> CurrentDecoration = new Dictionary<int, int>();
	}
}
