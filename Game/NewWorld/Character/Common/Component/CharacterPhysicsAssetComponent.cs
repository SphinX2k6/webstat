using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component
{
	// Token: 0x0200490E RID: 18702
	[NullableContext(1)]
	[Nullable(0)]
	public class CharacterPhysicsAssetComponent : EntityComponent, IComponentDependency
	{
		// Token: 0x1700834C RID: 33612
		// (get) Token: 0x06030DFC RID: 200188 RVA: 0x00C1BC2B File Offset: 0x00C19E2B
		public static Type[] Dependencies
		{
			get
			{
				return new Type[]
				{
					typeof(CharacterActorComponent),
					typeof(BaseTagComponent),
					typeof(CharacterAnimationComponent)
				};
			}
		}

		// Token: 0x06030DFD RID: 200189 RVA: 0x00C1BC5A File Offset: 0x00C19E5A
		private void OnStateInherit(Entity other, bool notInheritMoveAndAnim)
		{
			other.GetComponent<CharacterPhysicsAssetComponent>().PhysicsStateInstance.ClearAnimState();
		}

		// Token: 0x06030DFE RID: 200190 RVA: 0x00C1BC6C File Offset: 0x00C19E6C
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			this.PhysicsStateInstance = new PhysicsState();
			this.PhysicsLoader = new PhysicsAssetLoader();
			return true;
		}

		// Token: 0x06030DFF RID: 200191 RVA: 0x00C1BC88 File Offset: 0x00C19E88
		protected override bool OnStart()
		{
			this.ActorComp = base.Entity.GetComponent<CharacterActorComponent>();
			if (this.ActorComp.CreatureData.GetEntityType() != EEntityType.Player || !this.ActorComp.IsAutonomousProxy)
			{
				this.IsStart = false;
				this.ActorComp = null;
				return true;
			}
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			this.AnimComp = base.Entity.GetComponent<CharacterAnimationComponent>();
			string roleBody = this.ActorComp.CreatureData.GetRoleConfig().Value.RoleBody;
			PhysicsAssetConfig? physicsAssetConfigByRoleBody = ConfigBase<EntityPhysicsAssetConfig>.Instance.GetPhysicsAssetConfigByRoleBody(roleBody);
			foreach (int tagId in CharacterPhysicsAssetComponent.ListenedTags)
			{
				if (this.TagComp.HasTag(tagId))
				{
					this.ListenedTagsCount++;
				}
			}
			this.PhysicsStateInstance.InitBaseState(this.ListenedTagsCount > 0);
			this.IsStart = this.PhysicsLoader.SetDataAndLoadAsset(this.ActorComp, physicsAssetConfigByRoleBody.Value, delegate
			{
				this.SetPhysicsState(this.PhysicsStateInstance.Active, true);
			});
			if (!this.IsStart)
			{
				return true;
			}
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null && tagComp.Valid)
			{
				foreach (int num in CharacterPhysicsAssetComponent.ListenedTags)
				{
					if (this.TagComp.HasTag(num))
					{
						this.ListenedTagsCount++;
					}
					ITagTask tagTask = this.TagComp.ListenForTagAddOrRemove(new int?(num), new BaseTagComponent.TTagSwitchedCallback(this.OnListenedTagChanged), null);
					if (tagTask != null)
					{
						this.TagListeners.Add(tagTask);
					}
				}
			}
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
			return true;
		}

		// Token: 0x06030E00 RID: 200192 RVA: 0x00C1BE5C File Offset: 0x00C1A05C
		protected override bool OnClear()
		{
			foreach (ITagTask tagTask in this.TagListeners)
			{
				tagTask.EndTask();
			}
			this.TagListeners.Clear();
			this.PhysicsLoader.ClearData();
			if (!this.IsStart)
			{
				return true;
			}
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, bool>(base.Entity, EEventName.RoleOnStateInherit, new Action<Entity, bool>(this.OnStateInherit));
			return true;
		}

		// Token: 0x06030E01 RID: 200193 RVA: 0x00C1BEF0 File Offset: 0x00C1A0F0
		private void OnListenedTagChanged(int tagId, bool tagExist)
		{
			if (tagExist)
			{
				this.ListenedTagsCount++;
			}
			else
			{
				this.ListenedTagsCount--;
			}
			if (this.ListenedTagsCount == 0)
			{
				this.SetPhysicsState(false, false);
				return;
			}
			this.SetPhysicsState(true, false);
		}

		// Token: 0x06030E02 RID: 200194 RVA: 0x00C1BF2C File Offset: 0x00C1A12C
		private void SetPhysicsState(bool active, bool force = false)
		{
			if (this.PhysicsStateInstance.Active == active && !force)
			{
				return;
			}
			if (!this.PhysicsLoader.LoadSuccess)
			{
				return;
			}
			bool flag = true;
			if (active)
			{
				if (!this.ActorComp.SetMeshCollisionEnabled(ECollisionEnabled.PhysicsOnly, "布娃娃效果"))
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Character;
					ELogAuthor author = ELogAuthor.LJM;
					string message = "角色物理资产模拟设置CollisionEnable失败";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Entity", base.Entity.Id);
					instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					return;
				}
				if (!this.ActorComp.SetMeshCollisionObjectType(ECollisionChannel.ECC_PhysicsBody, "布娃娃效果"))
				{
					Log instance2 = Singleton<Log>.Instance;
					ELogModule module2 = ELogModule.Character;
					ELogAuthor author2 = ELogAuthor.LJM;
					string message2 = "角色物理资产模拟设置CollisionObjectType失败";
					ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("Entity", base.Entity.Id);
					instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
					return;
				}
				this.ActorComp.Actor.Mesh.bEnableShearAnim = false;
				foreach (string key in this.PhysicsLoader.BoneNames)
				{
					USkeletalMeshComponent mesh = this.ActorComp.Actor.Mesh;
					FName fname = FNameUtil.GetDynamicFName(key) ?? FName.NAME_None;
					mesh.SetAllBodiesBelowSimulatePhysics(fname, true, false);
				}
				if (this.IsDebug)
				{
					Log instance3 = Singleton<Log>.Instance;
					ELogModule module3 = ELogModule.Character;
					ELogAuthor author3 = ELogAuthor.LJM;
					string message3 = "角色开启物理资产模拟";
					ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("Entity", base.Entity.Id);
					instance3.Info(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
				}
			}
			else
			{
				flag = (flag && this.ActorComp.SetMeshCollisionEnabled(ECollisionEnabled.NoCollision, "布娃娃效果"));
				if (!flag || !this.ActorComp.SetMeshCollisionObjectType(ECollisionChannel.ECC_Pawn, "布娃娃效果"))
				{
					Log instance4 = Singleton<Log>.Instance;
					ELogModule module4 = ELogModule.Character;
					ELogAuthor author4 = ELogAuthor.LJM;
					string message4 = "角色物理资产模拟重新设置Collision失败";
					ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("Entity", base.Entity.Id);
					instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
					return;
				}
				this.ActorComp.Actor.Mesh.SetSimulatePhysics(false);
				this.ActorComp.Actor.Mesh.bEnableShearAnim = true;
				if (this.IsDebug)
				{
					Log instance5 = Singleton<Log>.Instance;
					ELogModule module5 = ELogModule.Character;
					ELogAuthor author5 = ELogAuthor.LJM;
					string message5 = "角色关闭物理资产模拟";
					ValueTuple<string, object> valueTuple5 = new ValueTuple<string, object>("Entity", base.Entity.Id);
					instance5.Info(module5, author5, message5, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple5));
				}
				this.AnimComp.MainAnimInstance.SavePoseSnapshot(CharacterPhysicsAssetComponent.RagDoll);
			}
			this.PhysicsStateInstance.SetNewState(active);
		}

		// Token: 0x06030E03 RID: 200195 RVA: 0x00C1C1CC File Offset: 0x00C1A3CC
		public bool GetRagRollQuitState()
		{
			bool quitCache = this.PhysicsStateInstance.QuitCache;
			this.PhysicsStateInstance.QuitCache = false;
			return quitCache;
		}

		// Token: 0x06030E04 RID: 200196 RVA: 0x00C1C1E8 File Offset: 0x00C1A3E8
		public void SetDebug(bool debug)
		{
			this.IsDebug = debug;
			if (this.IsDebug)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(248, 3);
				defaultInterpolatedStringHandler.AppendLiteral("\r\n            ------------------------角色物理资产管理组件开启Debug----------------------\r\n            -物理资产: ");
				defaultInterpolatedStringHandler.AppendFormatted<UPhysicsAsset>(this.ActorComp.Actor.Mesh.PhysicsAssetOverride);
				defaultInterpolatedStringHandler.AppendLiteral("\r\n            -驱动骨骼：");
				defaultInterpolatedStringHandler.AppendFormatted(string.Join(", ", this.PhysicsLoader.BoneNames));
				defaultInterpolatedStringHandler.AppendLiteral("\r\n            -脚本组件管理状态 是否激活：");
				defaultInterpolatedStringHandler.AppendFormatted<bool>(this.PhysicsStateInstance.Active);
				defaultInterpolatedStringHandler.AppendLiteral("\r\n            -------------------------------------------------------------------------\r\n            ");
				string message = defaultInterpolatedStringHandler.ToStringAndClear();
				Singleton<Log>.Instance.Info(ELogModule.Character, ELogAuthor.LJM, message, default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06030E05 RID: 200197 RVA: 0x00C1C2B0 File Offset: 0x00C1A4B0
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			CharacterPhysicsAssetComponent characterPhysicsAssetComponent = (CharacterPhysicsAssetComponent)componentTemplate;
			if (base.CanResetComponentProperty("IsStart"))
			{
				this.IsStart = characterPhysicsAssetComponent.IsStart;
			}
			if (base.CanResetComponentProperty("PhysicsStateInstance"))
			{
				if (characterPhysicsAssetComponent.PhysicsStateInstance == null)
				{
					this.PhysicsStateInstance = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PhysicsState>(this.PhysicsStateInstance), "PhysicsStateInstance"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("PhysicsLoader"))
			{
				if (characterPhysicsAssetComponent.PhysicsLoader == null)
				{
					this.PhysicsLoader = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PhysicsAssetLoader>(this.PhysicsLoader), "PhysicsLoader"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("ActorComp"))
			{
				if (characterPhysicsAssetComponent.ActorComp == null)
				{
					this.ActorComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterActorComponent>(this.ActorComp), "ActorComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (characterPhysicsAssetComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("AnimComp"))
			{
				if (characterPhysicsAssetComponent.AnimComp == null)
				{
					this.AnimComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterAnimationComponent>(this.AnimComp), "AnimComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagListeners") && characterPhysicsAssetComponent.TagListeners != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<ITagTask>>(this.TagListeners), "TagListeners"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("ListenedTagsCount"))
			{
				this.ListenedTagsCount = characterPhysicsAssetComponent.ListenedTagsCount;
			}
			if (base.CanResetComponentProperty("IsDebug"))
			{
				this.IsDebug = characterPhysicsAssetComponent.IsDebug;
			}
			return true;
		}

		// Token: 0x0401C180 RID: 115072
		[StaticVariableRuleIgnore]
		private static readonly FName RagDoll = new FName("RagDoll");

		// Token: 0x0401C181 RID: 115073
		private bool IsStart;

		// Token: 0x0401C182 RID: 115074
		[Nullable(2)]
		private PhysicsState PhysicsStateInstance;

		// Token: 0x0401C183 RID: 115075
		[Nullable(2)]
		private PhysicsAssetLoader PhysicsLoader;

		// Token: 0x0401C184 RID: 115076
		[Nullable(2)]
		private CharacterActorComponent ActorComp;

		// Token: 0x0401C185 RID: 115077
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401C186 RID: 115078
		[Nullable(2)]
		private CharacterAnimationComponent AnimComp;

		// Token: 0x0401C187 RID: 115079
		private readonly List<ITagTask> TagListeners = new List<ITagTask>();

		// Token: 0x0401C188 RID: 115080
		[StaticVariableRuleIgnore]
		private static readonly int[] ListenedTags = new int[]
		{
			GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"]
		};

		// Token: 0x0401C189 RID: 115081
		private int ListenedTagsCount;

		// Token: 0x0401C18A RID: 115082
		private bool IsDebug;
	}
}
