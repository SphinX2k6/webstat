using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Component;
using CSharpScript.Game.Module.GenericPrompt;

namespace CSharpScript.Game.NewWorld.Character.Monster.Component
{
	// Token: 0x020048DE RID: 18654
	[NullableContext(1)]
	[Nullable(0)]
	public class HackManagementComponent : EntityComponent
	{
		// Token: 0x06030AA7 RID: 199335 RVA: 0x00BFE880 File Offset: 0x00BFCA80
		[NullableContext(2)]
		protected override bool OnInitData(IEntityArgs args = null)
		{
			object param = args.GetP1<CreateEntityData>().GetParam<HackManagementComponent>();
			this.Config = (param as HackManagementComponent);
			this.MaxHackCount = this.Config.MaxHackingCount;
			return true;
		}

		// Token: 0x06030AA8 RID: 199336 RVA: 0x00BFE8B8 File Offset: 0x00BFCAB8
		protected override bool OnStart()
		{
			this.CreatureDataComp = base.Entity.GetComponent<CreatureDataComponent>();
			CreatureDataComponent creatureDataComp = this.CreatureDataComp;
			if (((creatureDataComp != null) ? creatureDataComp.PbHackingEntities : null) != null)
			{
				foreach (long creatureDataId in this.CreatureDataComp.PbHackingEntities)
				{
					EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(creatureDataId);
					if (entity != null)
					{
						WorldEntity entity2 = entity.Entity;
						if (entity2 != null && entity2.Valid)
						{
							this.CurrentHackEntity.Add(entity.Entity);
						}
					}
				}
			}
			this.TagComp = base.Entity.GetComponent<BaseTagComponent>();
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp != null)
			{
				tagComp.AddTag(new int?(HackManagementConstants.NUM_TAG_ID));
			}
			int remainingHackNumber = this.GetRemainingHackNumber();
			if (remainingHackNumber > 1)
			{
				BaseTagComponent tagComp2 = this.TagComp;
				if (tagComp2 != null)
				{
					tagComp2.TagContainer.UpdateExactTag(ETagChannel.Common, HackManagementConstants.NUM_TAG_ID, remainingHackNumber - 1);
				}
			}
			BaseTagComponent tagComp3 = this.TagComp;
			if (tagComp3 != null)
			{
				tagComp3.AddTagAddOrRemoveListener(HackManagementConstants.NUM_IS_EMPTY_TAG_ID, delegate(int tag, bool tagExist)
				{
					TimerSystem.Instance.Delay(delegate(float _)
					{
						this.HackNumIsEmpty = tagExist;
					}, 100f, null, null, true, 1f);
				}, null);
			}
			BaseTagComponent tagComp4 = this.TagComp;
			if (tagComp4 != null)
			{
				tagComp4.AddTagAddOrRemoveListener(HackManagementConstants.HACKING_TAG_ID, new BaseTagComponent.TTagSwitchedCallback(this.HackingTagListener), null);
			}
			return true;
		}

		// Token: 0x06030AA9 RID: 199337 RVA: 0x00BFE9E0 File Offset: 0x00BFCBE0
		private void HackingTagListener(int tag, bool tagExist)
		{
			double num = Singleton<Time>.Instance.Now - this.LastShowTipTime;
			if (tagExist && this.HackNumIsEmpty && num > 1000.0)
			{
				this.LastShowTipTime = Singleton<Time>.Instance.Now;
				string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ClientErrorCode_0_Text", null);
				ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType(EPromptSubViewType.FloatLinePrompt, null, null, new object[]
				{
					localTextNew
				}, null, null, null);
			}
		}

		// Token: 0x06030AAA RID: 199338 RVA: 0x00BFEA55 File Offset: 0x00BFCC55
		public bool CanHack()
		{
			return this.CurrentHackEntity.Count < this.MaxHackCount;
		}

		// Token: 0x06030AAB RID: 199339 RVA: 0x00BFEA6A File Offset: 0x00BFCC6A
		public void AddHackEntity(Entity entity)
		{
			this.CurrentHackEntity.Add(entity);
			BaseTagComponent tagComp = this.TagComp;
			if (tagComp == null)
			{
				return;
			}
			tagComp.TagContainer.UpdateExactTag(ETagChannel.Common, HackManagementConstants.NUM_TAG_ID, -1);
		}

		// Token: 0x06030AAC RID: 199340 RVA: 0x00BFEA94 File Offset: 0x00BFCC94
		public void RemoveHackEntity(Entity entity)
		{
			int num = this.CurrentHackEntity.IndexOf(entity);
			if (num != -1)
			{
				this.CurrentHackEntity.RemoveAt(num);
				BaseTagComponent tagComp = this.TagComp;
				if (tagComp == null)
				{
					return;
				}
				tagComp.TagContainer.UpdateExactTag(ETagChannel.Common, HackManagementConstants.NUM_TAG_ID, 1);
			}
		}

		// Token: 0x06030AAD RID: 199341 RVA: 0x00BFEADA File Offset: 0x00BFCCDA
		public int GetRemainingHackNumber()
		{
			return Math.Max(0, this.MaxHackCount - this.CurrentHackEntity.Count);
		}

		// Token: 0x06030AAE RID: 199342 RVA: 0x00BFEAF4 File Offset: 0x00BFCCF4
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			HackManagementComponent hackManagementComponent = (HackManagementComponent)componentTemplate;
			if (base.CanResetComponentProperty("Config"))
			{
				if (hackManagementComponent.Config == null)
				{
					this.Config = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<HackManagementComponent>(this.Config), "Config"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("CreatureDataComp"))
			{
				if (hackManagementComponent.CreatureDataComp == null)
				{
					this.CreatureDataComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CreatureDataComponent>(this.CreatureDataComp), "CreatureDataComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("TagComp"))
			{
				if (hackManagementComponent.TagComp == null)
				{
					this.TagComp = null;
				}
				else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseTagComponent>(this.TagComp), "TagComp"))
				{
					return false;
				}
			}
			if (base.CanResetComponentProperty("MaxHackCount"))
			{
				this.MaxHackCount = hackManagementComponent.MaxHackCount;
			}
			if (base.CanResetComponentProperty("CurrentHackEntity") && hackManagementComponent.CurrentHackEntity != null && !base.CheckClearObject(EntityComponentSystem.ClearObject<List<Entity>>(this.CurrentHackEntity), "CurrentHackEntity"))
			{
				return false;
			}
			if (base.CanResetComponentProperty("HackNumIsEmpty"))
			{
				this.HackNumIsEmpty = hackManagementComponent.HackNumIsEmpty;
			}
			if (base.CanResetComponentProperty("LastShowTipTime"))
			{
				this.LastShowTipTime = hackManagementComponent.LastShowTipTime;
			}
			return true;
		}

		// Token: 0x0401BF91 RID: 114577
		[Nullable(2)]
		private HackManagementComponent Config;

		// Token: 0x0401BF92 RID: 114578
		[Nullable(2)]
		private CreatureDataComponent CreatureDataComp;

		// Token: 0x0401BF93 RID: 114579
		[Nullable(2)]
		private BaseTagComponent TagComp;

		// Token: 0x0401BF94 RID: 114580
		private int MaxHackCount;

		// Token: 0x0401BF95 RID: 114581
		private readonly List<Entity> CurrentHackEntity = new List<Entity>();

		// Token: 0x0401BF96 RID: 114582
		private bool HackNumIsEmpty;

		// Token: 0x0401BF97 RID: 114583
		private double LastShowTipTime;
	}
}
