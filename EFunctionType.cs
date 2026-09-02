using System;

// Token: 0x02001CAE RID: 7342
public enum EFunctionType
{
	// Token: 0x0400661F RID: 26143
	Role = 10001,
	// Token: 0x04006620 RID: 26144
	Bag,
	// Token: 0x04006621 RID: 26145
	Calabash,
	// Token: 0x04006622 RID: 26146
	Quest,
	// Token: 0x04006623 RID: 26147
	CommonGamePlay,
	// Token: 0x04006624 RID: 26148
	TimeLimitGamePlay,
	// Token: 0x04006625 RID: 26149
	FormatTeam,
	// Token: 0x04006626 RID: 26150
	MakeTeam,
	// Token: 0x04006627 RID: 26151
	Gacha,
	// Token: 0x04006628 RID: 26152
	Shop,
	// Token: 0x04006629 RID: 26153
	Friend,
	// Token: 0x0400662A RID: 26154
	Guild,
	// Token: 0x0400662B RID: 26155
	Achievement,
	// Token: 0x0400662C RID: 26156
	HandBook,
	// Token: 0x0400662D RID: 26157
	Map,
	// Token: 0x0400662E RID: 26158
	RecruitmentDivision,
	// Token: 0x0400662F RID: 26159
	PowerModule,
	// Token: 0x04006630 RID: 26160
	TimeOfDay,
	// Token: 0x04006631 RID: 26161
	Menu,
	// Token: 0x04006632 RID: 26162
	Mail,
	// Token: 0x04006633 RID: 26163
	Online,
	// Token: 0x04006634 RID: 26164
	Tutorial,
	// Token: 0x04006635 RID: 26165
	AdventureGuide,
	// Token: 0x04006636 RID: 26166
	RoleQuest = 10025,
	// Token: 0x04006637 RID: 26167
	ExploreTool,
	// Token: 0x04006638 RID: 26168
	FunctionRoulette = 10056,
	// Token: 0x04006639 RID: 26169
	ExploreProgressReward,
	// Token: 0x0400663A RID: 26170
	KuroStreet,
	// Token: 0x0400663B RID: 26171
	SingleTimeTower = 10027,
	// Token: 0x0400663C RID: 26172
	UserFeedback,
	// Token: 0x0400663D RID: 26173
	InfluenceReputation,
	// Token: 0x0400663E RID: 26174
	CycleTower,
	// Token: 0x0400663F RID: 26175
	ShowLockOnButton,
	// Token: 0x04006640 RID: 26176
	WuYinQu,
	// Token: 0x04006641 RID: 26177
	Forging = 10034,
	// Token: 0x04006642 RID: 26178
	Compose,
	// Token: 0x04006643 RID: 26179
	ConcertoResponse,
	// Token: 0x04006644 RID: 26180
	BattlePass = 10040,
	// Token: 0x04006645 RID: 26181
	RoleHandBook,
	// Token: 0x04006646 RID: 26182
	RoleTeach = 10043,
	// Token: 0x04006647 RID: 26183
	InstanceWeapon,
	// Token: 0x04006648 RID: 26184
	InstanceSkill,
	// Token: 0x04006649 RID: 26185
	InstanceLevel,
	// Token: 0x0400664A RID: 26186
	InstanceElement,
	// Token: 0x0400664B RID: 26187
	Advice,
	// Token: 0x0400664C RID: 26188
	Photograph,
	// Token: 0x0400664D RID: 26189
	AdvicePut,
	// Token: 0x0400664E RID: 26190
	HandBookSystem,
	// Token: 0x0400664F RID: 26191
	RoleElementChange,
	// Token: 0x04006650 RID: 26192
	NewTower = 10055,
	// Token: 0x04006651 RID: 26193
	Activity = 10053,
	// Token: 0x04006652 RID: 26194
	PersonalSystem = 10060,
	// Token: 0x04006653 RID: 26195
	PersonalCard,
	// Token: 0x04006654 RID: 26196
	JiYinHuiChuan = 10023001,
	// Token: 0x04006655 RID: 26197
	HuiYinJieXiang,
	// Token: 0x04006656 RID: 26198
	WuYinQv,
	// Token: 0x04006657 RID: 26199
	ShengZhiLingYu,
	// Token: 0x04006658 RID: 26200
	DailyActivity,
	// Token: 0x04006659 RID: 26201
	VisionIdentify = 10001004,
	// Token: 0x0400665A RID: 26202
	Roguelike = 110056,
	// Token: 0x0400665B RID: 26203
	BoosRush = 110058,
	// Token: 0x0400665C RID: 26204
	LordGym = 110057,
	// Token: 0x0400665D RID: 26205
	PowerStore = 10066,
	// Token: 0x0400665E RID: 26206
	VisionRecovery = 10024001,
	// Token: 0x0400665F RID: 26207
	VisionRefine = 10083,
	// Token: 0x04006660 RID: 26208
	PowerMagnificationReward = 10071,
	// Token: 0x04006661 RID: 26209
	MailBind,
	// Token: 0x04006662 RID: 26210
	Fishing,
	// Token: 0x04006663 RID: 26211
	VisionRecommend,
	// Token: 0x04006664 RID: 26212
	VisionGroup,
	// Token: 0x04006665 RID: 26213
	FishingItemDelete,
	// Token: 0x04006666 RID: 26214
	FishingItemSail,
	// Token: 0x04006667 RID: 26215
	FishingTech,
	// Token: 0x04006668 RID: 26216
	FishingPhoebeTech = 100781,
	// Token: 0x04006669 RID: 26217
	FishingHandBook = 10079,
	// Token: 0x0400666A RID: 26218
	FishingGhostShip,
	// Token: 0x0400666B RID: 26219
	FishingEntrust = 100081,
	// Token: 0x0400666C RID: 26220
	ShipTower = 10081,
	// Token: 0x0400666D RID: 26221
	PlayerTitle,
	// Token: 0x0400666E RID: 26222
	BirthdayReward = 10084,
	// Token: 0x0400666F RID: 26223
	GameIntroduction = 10086,
	// Token: 0x04006670 RID: 26224
	PhantomArenaCoreCardSlot = 10085,
	// Token: 0x04006671 RID: 26225
	PhantomArenaCollect = 10088,
	// Token: 0x04006672 RID: 26226
	PhantomArenaRole,
	// Token: 0x04006673 RID: 26227
	PhantomArenaCard,
	// Token: 0x04006674 RID: 26228
	PhantomArenaCardUnlock,
	// Token: 0x04006675 RID: 26229
	PhantomArenaCardOutlookUnlock,
	// Token: 0x04006676 RID: 26230
	PhantomArenaSkipFuncUnlock,
	// Token: 0x04006677 RID: 26231
	DirectTrainPro = 10095,
	// Token: 0x04006678 RID: 26232
	Soar = 10026010,
	// Token: 0x04006679 RID: 26233
	RoleDev = 10097,
	// Token: 0x0400667A RID: 26234
	MotorDevelop,
	// Token: 0x0400667B RID: 26235
	MotorTechTree,
	// Token: 0x0400667C RID: 26236
	MotorFreezeWater = 10143,
	// Token: 0x0400667D RID: 26237
	HonamiStoryBackpack = 10102,
	// Token: 0x0400667E RID: 26238
	HonamiStoryMainQuestLifeSupport,
	// Token: 0x0400667F RID: 26239
	HonamiStoryBackpackStage1FuncId,
	// Token: 0x04006680 RID: 26240
	HonamiStoryLifeSupport,
	// Token: 0x04006681 RID: 26241
	SafeLeaveBuyFuncId = 10115,
	// Token: 0x04006682 RID: 26242
	ChangeDangerFuncId = 10121,
	// Token: 0x04006683 RID: 26243
	TowerOpenFuncId = 10120,
	// Token: 0x04006684 RID: 26244
	LvSelectOpenFuncId = 10112,
	// Token: 0x04006685 RID: 26245
	HonamiStoryPollution = 10114,
	// Token: 0x04006686 RID: 26246
	HonamiStoryRoleSelectFuncId = 10111,
	// Token: 0x04006687 RID: 26247
	HonamiStoryWeaponSelectFuncId = 10123,
	// Token: 0x04006688 RID: 26248
	HonamiStoryMascotFuncId = 10116,
	// Token: 0x04006689 RID: 26249
	HonamiStoryAreaTaskFuncId = 10113,
	// Token: 0x0400668A RID: 26250
	HonamiStoryShopFuncId = 10117,
	// Token: 0x0400668B RID: 26251
	HonamiStoryItemCollectFuncId,
	// Token: 0x0400668C RID: 26252
	HonamiStoryTechFuncId = 10107,
	// Token: 0x0400668D RID: 26253
	HonamiStoryMainQuestFuncId = 10124,
	// Token: 0x0400668E RID: 26254
	HonamiStoryLifeSupportCanUpdate = 10122,
	// Token: 0x0400668F RID: 26255
	PhoneMsg = 10130,
	// Token: 0x04006690 RID: 26256
	Infrastructure,
	// Token: 0x04006691 RID: 26257
	PermanentPhantomArea,
	// Token: 0x04006692 RID: 26258
	PermanentPhantomAreaCollect = 10135,
	// Token: 0x04006693 RID: 26259
	PermanentPhantomArenaRole,
	// Token: 0x04006694 RID: 26260
	PermanentPhantomArenaCard,
	// Token: 0x04006695 RID: 26261
	PermanentPhantomArenaCardUnlock,
	// Token: 0x04006696 RID: 26262
	PermanentPhantomArenaRecommend,
	// Token: 0x04006697 RID: 26263
	PermanentPhantomArenaSkipFuncUnlock = 10141,
	// Token: 0x04006698 RID: 26264
	PermanentPhantomArenaCoreCardSlot,
	// Token: 0x04006699 RID: 26265
	WeatherCentral = 10133,
	// Token: 0x0400669A RID: 26266
	FeedbackReward = 10140,
	// Token: 0x0400669B RID: 26267
	VisionAim = 10100,
	// Token: 0x0400669C RID: 26268
	MotorSoar = 10154,
	// Token: 0x0400669D RID: 26269
	VillageInfr = 10150,
	// Token: 0x0400669E RID: 26270
	PinballDailyLevel,
	// Token: 0x0400669F RID: 26271
	PinballRole,
	// Token: 0x040066A0 RID: 26272
	PinballShop,
	// Token: 0x040066A1 RID: 26273
	WeeklyChallenge = 10155,
	// Token: 0x040066A2 RID: 26274
	SheriffAnomaly,
	// Token: 0x040066A3 RID: 26275
	SheriffQuest
}
