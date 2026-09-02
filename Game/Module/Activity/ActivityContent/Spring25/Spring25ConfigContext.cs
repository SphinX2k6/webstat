using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Spring25
{
	// Token: 0x0200635D RID: 25437
	[NullableContext(1)]
	[Nullable(0)]
	public class Spring25ConfigContext
	{
		// Token: 0x17009CBF RID: 40127
		// (get) Token: 0x0603FDC4 RID: 261572 RVA: 0x01061B68 File Offset: 0x0105FD68
		private Dictionary<int, SpringSign> SignCfgCache
		{
			get
			{
				if (this.SignCfgCacheInternal == null)
				{
					this.SignCfgCacheInternal = new Dictionary<int, SpringSign>();
					IReadOnlyList<SpringSign> configList = ConfigSpringSignAll.GetConfigList(true);
					if (configList != null)
					{
						int currentActivityId = this.AttachedModel.CurrentActivityId;
						foreach (SpringSign value in configList)
						{
							if (currentActivityId == value.ActivityId)
							{
								this.SignCfgCacheInternal[value.Id] = value;
							}
						}
					}
				}
				return this.SignCfgCacheInternal;
			}
		}

		// Token: 0x17009CC0 RID: 40128
		// (get) Token: 0x0603FDC5 RID: 261573 RVA: 0x01061BF8 File Offset: 0x0105FDF8
		private Dictionary<int, SpringReward> TaskCfgCache
		{
			get
			{
				if (this.TaskCfgCacheInternal == null)
				{
					this.TaskCfgCacheInternal = new Dictionary<int, SpringReward>();
					IReadOnlyList<SpringReward> configList = ConfigSpringRewardAll.GetConfigList(true);
					if (configList != null)
					{
						int currentActivityId = this.AttachedModel.CurrentActivityId;
						foreach (SpringReward value in configList)
						{
							if (currentActivityId == value.ActivityId)
							{
								this.TaskCfgCacheInternal[value.Id] = value;
							}
						}
					}
				}
				return this.TaskCfgCacheInternal;
			}
		}

		// Token: 0x0603FDC6 RID: 261574 RVA: 0x01061C88 File Offset: 0x0105FE88
		public Spring25ConfigContext(Spring25Model model)
		{
			this.AttachedModel = model;
		}

		// Token: 0x0603FDC7 RID: 261575 RVA: 0x01061C97 File Offset: 0x0105FE97
		public void Dispose()
		{
			Dictionary<int, SpringReward> taskCfgCacheInternal = this.TaskCfgCacheInternal;
			if (taskCfgCacheInternal != null)
			{
				taskCfgCacheInternal.Clear();
			}
			this.TaskCfgCacheInternal = null;
			Dictionary<int, SpringSign> signCfgCacheInternal = this.SignCfgCacheInternal;
			if (signCfgCacheInternal != null)
			{
				signCfgCacheInternal.Clear();
			}
			this.SignCfgCacheInternal = null;
		}

		// Token: 0x0603FDC8 RID: 261576 RVA: 0x01061CCC File Offset: 0x0105FECC
		private SpringResource? GetResourceCfgBySignId(int id)
		{
			SpringSign springSign;
			int p0RoleType = this.SignCfgCache.TryGetValue(id, out springSign) ? springSign.ResourceTypeId : 0;
			IReadOnlyList<SpringResource> configList = ConfigSpringResourceByRoleType.GetConfigList(p0RoleType, true);
			if (configList == null)
			{
				return null;
			}
			if (configList.Count <= 0)
			{
				return null;
			}
			return new SpringResource?(configList[0]);
		}

		// Token: 0x17009CC1 RID: 40129
		// (get) Token: 0x0603FDC9 RID: 261577 RVA: 0x01061D28 File Offset: 0x0105FF28
		public Dictionary<int, SpringReward> TaskCfgMap
		{
			get
			{
				return this.TaskCfgCache;
			}
		}

		// Token: 0x17009CC2 RID: 40130
		// (get) Token: 0x0603FDCA RID: 261578 RVA: 0x01061D30 File Offset: 0x0105FF30
		public Dictionary<int, SpringSign> SignCfgMap
		{
			get
			{
				return this.SignCfgCache;
			}
		}

		// Token: 0x17009CC3 RID: 40131
		// (get) Token: 0x0603FDCB RID: 261579 RVA: 0x01061D38 File Offset: 0x0105FF38
		public int TaskCount
		{
			get
			{
				return this.TaskCfgMap.Count;
			}
		}

		// Token: 0x17009CC4 RID: 40132
		// (get) Token: 0x0603FDCC RID: 261580 RVA: 0x01061D45 File Offset: 0x0105FF45
		public int SignCount
		{
			get
			{
				return this.SignCfgCache.Count;
			}
		}

		// Token: 0x0603FDCD RID: 261581 RVA: 0x01061D52 File Offset: 0x0105FF52
		public SpringChat? StartChatCfgByGender(EPlayerGender gender)
		{
			if (gender == EPlayerGender.Male)
			{
				return ConfigSpringChatById.GetConfig(99, true);
			}
			return ConfigSpringChatById.GetConfig(100, true);
		}

		// Token: 0x0603FDCE RID: 261582 RVA: 0x01061D6C File Offset: 0x0105FF6C
		public SpringChat? GetChatConfigBySignId(int id, EPlayerGender gender)
		{
			SpringResource? resourceCfgBySignId = this.GetResourceCfgBySignId(id);
			if (resourceCfgBySignId == null)
			{
				return null;
			}
			int[] array = resourceCfgBySignId.Value.DialogDataList();
			if (array.Length < 2)
			{
				return null;
			}
			int p0Id;
			if (gender == EPlayerGender.Male)
			{
				p0Id = array[0];
			}
			else
			{
				p0Id = array[1];
			}
			return ConfigSpringChatById.GetConfig(p0Id, true);
		}

		// Token: 0x0603FDCF RID: 261583 RVA: 0x01061DCC File Offset: 0x0105FFCC
		[NullableContext(2)]
		public string GetLetterContentTextIdBySignId(int id)
		{
			SpringResource? resourceCfgBySignId = this.GetResourceCfgBySignId(id);
			if (resourceCfgBySignId == null)
			{
				return null;
			}
			return resourceCfgBySignId.GetValueOrDefault().LetterContent;
		}

		// Token: 0x0603FDD0 RID: 261584 RVA: 0x01061DFC File Offset: 0x0105FFFC
		[NullableContext(2)]
		public string GetLetterTitleTextIdBySignId(int id)
		{
			SpringResource? resourceCfgBySignId = this.GetResourceCfgBySignId(id);
			if (resourceCfgBySignId == null)
			{
				return null;
			}
			return resourceCfgBySignId.GetValueOrDefault().LetterTitle;
		}

		// Token: 0x0603FDD1 RID: 261585 RVA: 0x01061E2C File Offset: 0x0106002C
		[NullableContext(2)]
		public string GetLetterTabTextIdBySignId(int id)
		{
			SpringResource? resourceCfgBySignId = this.GetResourceCfgBySignId(id);
			if (resourceCfgBySignId == null)
			{
				return null;
			}
			return resourceCfgBySignId.GetValueOrDefault().LetterTab;
		}

		// Token: 0x0603FDD2 RID: 261586 RVA: 0x01061E5C File Offset: 0x0106005C
		[NullableContext(2)]
		public string GetLetterIconBySignId(int id)
		{
			SpringResource? resourceCfgBySignId = this.GetResourceCfgBySignId(id);
			if (resourceCfgBySignId == null)
			{
				return null;
			}
			return resourceCfgBySignId.GetValueOrDefault().MailIcon;
		}

		// Token: 0x0603FDD3 RID: 261587 RVA: 0x01061E8C File Offset: 0x0106008C
		[NullableContext(2)]
		public string GetRoleNameTextIdBySignId(int id)
		{
			SpringResource? resourceCfgBySignId = this.GetResourceCfgBySignId(id);
			if (resourceCfgBySignId == null)
			{
				return null;
			}
			return resourceCfgBySignId.GetValueOrDefault().RoleName;
		}

		// Token: 0x0603FDD4 RID: 261588 RVA: 0x01061EBC File Offset: 0x010600BC
		public ESpring25RoleType? GetResourceTypeBySignId(int id)
		{
			SpringSign? config = ConfigSpringSignById.GetConfig(id, true);
			bool flag;
			if (config == null)
			{
				flag = false;
			}
			else
			{
				int resourceTypeId = config.GetValueOrDefault().ResourceTypeId;
				flag = true;
			}
			if (!flag)
			{
				return null;
			}
			config = ConfigSpringSignById.GetConfig(id, true);
			return new ESpring25RoleType?((ESpring25RoleType)config.Value.ResourceTypeId);
		}

		// Token: 0x0603FDD5 RID: 261589 RVA: 0x01061F18 File Offset: 0x01060118
		[NullableContext(2)]
		public string GetTaskNameTextIdByTaskId(int id)
		{
			SpringReward springReward;
			this.TaskCfgCache.TryGetValue(id, out springReward);
			return springReward.TaskTitle;
		}

		// Token: 0x0603FDD6 RID: 261590 RVA: 0x01061F3C File Offset: 0x0106013C
		public int GetTaskThresholdByTaskId(int id)
		{
			SpringReward springReward;
			this.TaskCfgCache.TryGetValue(id, out springReward);
			return springReward.TaskThreshold;
		}

		// Token: 0x04023E5E RID: 147038
		private readonly Spring25Model AttachedModel;

		// Token: 0x04023E5F RID: 147039
		[Nullable(2)]
		private Dictionary<int, SpringSign> SignCfgCacheInternal;

		// Token: 0x04023E60 RID: 147040
		[Nullable(2)]
		private Dictionary<int, SpringReward> TaskCfgCacheInternal;
	}
}
