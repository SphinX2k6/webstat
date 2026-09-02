using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.NewWorld.SceneItem;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052FE RID: 21246
	[NullableContext(1)]
	[Nullable(0)]
	public class QuickHackMarksItem : UiPanelBase
	{
		// Token: 0x060363BA RID: 222138 RVA: 0x00DAA824 File Offset: 0x00DA8A24
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060363BB RID: 222139 RVA: 0x00DAA88D File Offset: 0x00DA8A8D
		protected override void OnStart()
		{
			base.GetItem(1).SetUIActive(false);
		}

		// Token: 0x060363BC RID: 222140 RVA: 0x00DAA89C File Offset: 0x00DA8A9C
		protected override void OnBeforeDestroy()
		{
			this.Owner = null;
			this.OnMarksFinish = null;
			this.SocketName = null;
			this.WorldLocationOffset = null;
		}

		// Token: 0x060363BD RID: 222141 RVA: 0x00DAA8C0 File Offset: 0x00DA8AC0
		public void RegisterMarkOwner(EntityHandle owner, Action<EntityHandle> onMarksFinish)
		{
			this.Owner = owner;
			this.OnMarksFinish = onMarksFinish;
			WorldEntity entity = owner.Entity;
			SceneItemQuickHackComponent component = entity.GetComponent<SceneItemQuickHackComponent>();
			if (component != null)
			{
				Vector hackIconOffset = component.GetHackIconOffset();
				if (hackIconOffset != null)
				{
					this.WorldLocationOffset = Vector.Create();
					this.WorldLocationOffset.DeepCopy(hackIconOffset);
				}
				return;
			}
			BaseActorComponent component2 = entity.GetComponent<BaseActorComponent>();
			AActor aactor = (component2 != null) ? component2.Owner : null;
			BaseInfoComponent baseInfo = entity.GetComponent<CreatureDataComponent>().GetBaseInfo();
			IHeadStateViewConfig headStateViewConfig = (baseInfo != null) ? baseInfo.HeadStateViewConfig : null;
			if (headStateViewConfig != null)
			{
				this.WorldLocationOffset = Vector.Create();
				this.WorldLocationOffset.Z = (double)(headStateViewConfig.ZOffset + 30);
				TsBaseCharacter tsBaseCharacter = aactor as TsBaseCharacter;
				if (tsBaseCharacter != null)
				{
					string headStateSocketName = headStateViewConfig.HeadStateSocketName;
					FName? fname = (headStateSocketName != null) ? FNameUtil.GetDynamicFName(headStateSocketName) : null;
					FName? socketName = (fname != null) ? fname : FNameUtil.GetDynamicFName("MarkCase");
					USkeletalMeshComponent mesh = tsBaseCharacter.Mesh;
					if (mesh != null && mesh.DoesSocketExist(socketName.Value))
					{
						this.SocketName = socketName;
					}
				}
			}
		}

		// Token: 0x060363BE RID: 222142 RVA: 0x00DAA9D0 File Offset: 0x00DA8BD0
		public bool GetWorldLocation(Vector outVector)
		{
			if (this.Owner == null || !this.Owner.Valid)
			{
				return false;
			}
			BaseActorComponent component = this.Owner.Entity.GetComponent<BaseActorComponent>();
			AActor aactor = (component != null) ? component.Owner : null;
			if (aactor == null)
			{
				return false;
			}
			bool flag = false;
			TsBaseCharacter tsBaseCharacter = aactor as TsBaseCharacter;
			if (tsBaseCharacter != null && this.SocketName != null)
			{
				USkeletalMeshComponent mesh = tsBaseCharacter.Mesh;
				if (mesh != null)
				{
					FVectorDouble fvectorDouble = mesh.D_GetSocketLocation(this.SocketName.Value);
					outVector.FromUeVector(fvectorDouble);
					flag = true;
				}
			}
			if (!flag)
			{
				outVector.FromUeVector(component.ActorLocationProxy);
			}
			if (this.WorldLocationOffset != null)
			{
				outVector.AdditionEqual(this.WorldLocationOffset);
			}
			return true;
		}

		// Token: 0x060363BF RID: 222143 RVA: 0x00DAAA80 File Offset: 0x00DA8C80
		public UniTask StartMarkAsync(QuickHackMarkInstance mark)
		{
			QuickHackMarksItem.<StartMarkAsync>d__15 <StartMarkAsync>d__;
			<StartMarkAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<StartMarkAsync>d__.<>4__this = this;
			<StartMarkAsync>d__.mark = mark;
			<StartMarkAsync>d__.<>1__state = -1;
			<StartMarkAsync>d__.<>t__builder.Start<QuickHackMarksItem.<StartMarkAsync>d__15>(ref <StartMarkAsync>d__);
			return <StartMarkAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060363C0 RID: 222144 RVA: 0x00DAAACC File Offset: 0x00DA8CCC
		private void OnFinishMark(int markId)
		{
			int count = this.ShowingIconIndices.Count;
			for (int i = 0; i < count; i++)
			{
				int num = this.ShowingIconIndices[i];
				QuickHackMarksIconItem quickHackMarksIconItem = this.IconList[num];
				if (quickHackMarksIconItem.GetMarkId() == markId)
				{
					quickHackMarksIconItem.SetActive(false);
					this.ShowingIconIndices.RemoveAt(i);
					this.ShowingMarkIdSet.Remove(markId);
					this.IdleIndexQueue.Push(num);
					break;
				}
			}
			if (this.ShowingIconIndices.Count <= 0 && this.OnMarksFinish != null && this.Owner != null)
			{
				this.OnMarksFinish(this.Owner);
			}
		}

		// Token: 0x0401F2EA RID: 127722
		private const int HEAD_DEFAULT_OFFSET = 30;

		// Token: 0x0401F2EB RID: 127723
		[Nullable(2)]
		private EntityHandle Owner;

		// Token: 0x0401F2EC RID: 127724
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<EntityHandle> OnMarksFinish;

		// Token: 0x0401F2ED RID: 127725
		private readonly List<QuickHackMarksIconItem> IconList = new List<QuickHackMarksIconItem>();

		// Token: 0x0401F2EE RID: 127726
		private readonly List<int> ShowingIconIndices = new List<int>();

		// Token: 0x0401F2EF RID: 127727
		private readonly HashSet<int> ShowingMarkIdSet = new HashSet<int>();

		// Token: 0x0401F2F0 RID: 127728
		private readonly Queue<int> IdleIndexQueue = new Queue<int>(4);

		// Token: 0x0401F2F1 RID: 127729
		private FName? SocketName;

		// Token: 0x0401F2F2 RID: 127730
		[Nullable(2)]
		private Vector WorldLocationOffset;

		// Token: 0x0200B22F RID: 45615
		[NullableContext(0)]
		private class EComponentType
		{
			// Token: 0x040373AE RID: 226222
			public const int IconLayout = 0;

			// Token: 0x040373AF RID: 226223
			public const int IconItem = 1;
		}
	}
}
