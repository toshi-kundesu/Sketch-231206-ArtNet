using System;
using UnityEngine;
using System.Collections;
// List用
using System.Collections.Generic;

[Serializable]
public class DMXChannel : MonoBehaviour
{
    
    
    // アニメーションさせる用に、フィールドをpublicにする
    #region ArtNetChannels field
    [Range(0, 255)]
    public int Ch1;
    [Range(0, 255)]
    public int Ch2;
    [Range(0, 255)]
    public int Ch3;
    [Range(0, 255)]
    public int Ch4;
    [Range(0, 255)]
    public int Ch5;
    [Range(0, 255)]
    public int Ch6;
    [Range(0, 255)]
    public int Ch7;
    [Range(0, 255)]
    public int Ch8;
    [Range(0, 255)]
    public int Ch9;
    [Range(0, 255)]
    public int Ch10;
    [Range(0, 255)]
    public int Ch11;
    [Range(0, 255)]
    public int Ch12;
    [Range(0, 255)]
    public int Ch13;
    [Range(0, 255)]
    public int Ch14;
    [Range(0, 255)]
    public int Ch15;
    [Range(0, 255)]
    public int Ch16;
    [Range(0, 255)]
    public int Ch17;
    [Range(0, 255)]
    public int Ch18;
    [Range(0, 255)]
    public int Ch19;
    [Range(0, 255)]
    public int Ch20;
    [Range(0, 255)]
    public int Ch21;
    [Range(0, 255)]
    public int Ch22;
    [Range(0, 255)]
    public int Ch23;
    [Range(0, 255)]
    public int Ch24;
    [Range(0, 255)]
    public int Ch25;
    [Range(0, 255)]
    public int Ch26;
    [Range(0, 255)]
    public int Ch27;
    [Range(0, 255)]
    public int Ch28;
    [Range(0, 255)]
    public int Ch29;
    [Range(0, 255)]
    public int Ch30;
    [Range(0, 255)]
    public int Ch31;
    [Range(0, 255)]
    public int Ch32;
    [Range(0, 255)]
    public int Ch33;
    [Range(0, 255)]
    public int Ch34;
    [Range(0, 255)]
    public int Ch35;
    [Range(0, 255)]
    public int Ch36;
    [Range(0, 255)]
    public int Ch37;
    [Range(0, 255)]
    public int Ch38;
    [Range(0, 255)]
    public int Ch39;
    [Range(0, 255)]
    public int Ch40;
    [Range(0, 255)]
    public int Ch41;
    [Range(0, 255)]
    public int Ch42;
    [Range(0, 255)]
    public int Ch43;
    [Range(0, 255)]
    public int Ch44;
    [Range(0, 255)]
    public int Ch45;
    [Range(0, 255)]
    public int Ch46;
    [Range(0, 255)]
    public int Ch47;
    [Range(0, 255)]
    public int Ch48;
    [Range(0, 255)]
    public int Ch49;
    [Range(0, 255)]
    public int Ch50;
    [Range(0, 255)]
    public int Ch51;
    [Range(0, 255)]
    public int Ch52;
    [Range(0, 255)]
    public int Ch53;
    [Range(0, 255)]
    public int Ch54;
    [Range(0, 255)]
    public int Ch55;
    [Range(0, 255)]
    public int Ch56;
    [Range(0, 255)]
    public int Ch57;
    [Range(0, 255)]
    public int Ch58;
    [Range(0, 255)]
    public int Ch59;
    [Range(0, 255)]
    public int Ch60;
    [Range(0, 255)]
    public int Ch61;
    [Range(0, 255)]
    public int Ch62;
    [Range(0, 255)]
    public int Ch63;
    [Range(0, 255)]
    public int Ch64;
    [Range(0, 255)]
    public int Ch65;
    [Range(0, 255)]
    public int Ch66;
    [Range(0, 255)]
    public int Ch67;
    [Range(0, 255)]
    public int Ch68;
    [Range(0, 255)]
    public int Ch69;
    [Range(0, 255)]
    public int Ch70;
    [Range(0, 255)]
    public int Ch71;
    [Range(0, 255)]
    public int Ch72;
    [Range(0, 255)]
    public int Ch73;
    [Range(0, 255)]
    public int Ch74;
    [Range(0, 255)]
    public int Ch75;
    [Range(0, 255)]
    public int Ch76;
    [Range(0, 255)]
    public int Ch77;
    [Range(0, 255)]
    public int Ch78;
    [Range(0, 255)]
    public int Ch79;
    [Range(0, 255)]
    public int Ch80;
    [Range(0, 255)]
    public int Ch81;
    [Range(0, 255)]
    public int Ch82;
    [Range(0, 255)]
    public int Ch83;
    [Range(0, 255)]
    public int Ch84;
    [Range(0, 255)]
    public int Ch85;
    [Range(0, 255)]
    public int Ch86;
    [Range(0, 255)]
    public int Ch87;
    [Range(0, 255)]
    public int Ch88;
    [Range(0, 255)]
    public int Ch89;
    [Range(0, 255)]
    public int Ch90;
    [Range(0, 255)]
    public int Ch91;
    [Range(0, 255)]
    public int Ch92;
    [Range(0, 255)]
    public int Ch93;
    [Range(0, 255)]
    public int Ch94;
    [Range(0, 255)]
    public int Ch95;
    [Range(0, 255)]
    public int Ch96;
    [Range(0, 255)]
    public int Ch97;
    [Range(0, 255)]
    public int Ch98;
    [Range(0, 255)]
    public int Ch99;
    [Range(0, 255)]
    public int Ch100;
    [Range(0, 255)]
    public int Ch101;
    [Range(0, 255)]
    public int Ch102;
    [Range(0, 255)]
    public int Ch103;
    [Range(0, 255)]
    public int Ch104;
    [Range(0, 255)]
    public int Ch105;
    [Range(0, 255)]
    public int Ch106;
    [Range(0, 255)]
    public int Ch107;
    [Range(0, 255)]
    public int Ch108;
    [Range(0, 255)]
    public int Ch109;
    [Range(0, 255)]
    public int Ch110;
    [Range(0, 255)]
    public int Ch111;
    [Range(0, 255)]
    public int Ch112;
    [Range(0, 255)]
    public int Ch113;
    [Range(0, 255)]
    public int Ch114;
    [Range(0, 255)]
    public int Ch115;
    [Range(0, 255)]
    public int Ch116;
    [Range(0, 255)]
    public int Ch117;
    [Range(0, 255)]
    public int Ch118;
    [Range(0, 255)]
    public int Ch119;
    [Range(0, 255)]
    public int Ch120;
    [Range(0, 255)]
    public int Ch121;
    [Range(0, 255)]
    public int Ch122;
    [Range(0, 255)]
    public int Ch123;
    [Range(0, 255)]
    public int Ch124;
    [Range(0, 255)]
    public int Ch125;
    [Range(0, 255)]
    public int Ch126;
    [Range(0, 255)]
    public int Ch127;
    [Range(0, 255)]
    public int Ch128;
    [Range(0, 255)]
    public int Ch129;
    [Range(0, 255)]
    public int Ch130;
    [Range(0, 255)]
    public int Ch131;
    [Range(0, 255)]
    public int Ch132;
    [Range(0, 255)]
    public int Ch133;
    [Range(0, 255)]
    public int Ch134;
    [Range(0, 255)]
    public int Ch135;
    [Range(0, 255)]
    public int Ch136;
    [Range(0, 255)]
    public int Ch137;
    [Range(0, 255)]
    public int Ch138;
    [Range(0, 255)]
    public int Ch139;
    [Range(0, 255)]
    public int Ch140;
    [Range(0, 255)]
    public int Ch141;
    [Range(0, 255)]
    public int Ch142;
    [Range(0, 255)]
    public int Ch143;
    [Range(0, 255)]
    public int Ch144;
    [Range(0, 255)]
    public int Ch145;
    [Range(0, 255)]
    public int Ch146;
    [Range(0, 255)]
    public int Ch147;
    [Range(0, 255)]
    public int Ch148;
    [Range(0, 255)]
    public int Ch149;
    [Range(0, 255)]
    public int Ch150;
    [Range(0, 255)]
    public int Ch151;
    [Range(0, 255)]
    public int Ch152;
    [Range(0, 255)]
    public int Ch153;
    [Range(0, 255)]
    public int Ch154;
    [Range(0, 255)]
    public int Ch155;
    [Range(0, 255)]
    public int Ch156;
    [Range(0, 255)]
    public int Ch157;
    [Range(0, 255)]
    public int Ch158;
    [Range(0, 255)]
    public int Ch159;
    [Range(0, 255)]
    public int Ch160;
    [Range(0, 255)]
    public int Ch161;
    [Range(0, 255)]
    public int Ch162;
    [Range(0, 255)]
    public int Ch163;
    [Range(0, 255)]
    public int Ch164;
    [Range(0, 255)]
    public int Ch165;
    [Range(0, 255)]
    public int Ch166;
    [Range(0, 255)]
    public int Ch167;
    [Range(0, 255)]
    public int Ch168;
    [Range(0, 255)]
    public int Ch169;
    [Range(0, 255)]
    public int Ch170;
    [Range(0, 255)]
    public int Ch171;
    [Range(0, 255)]
    public int Ch172;
    [Range(0, 255)]
    public int Ch173;
    [Range(0, 255)]
    public int Ch174;
    [Range(0, 255)]
    public int Ch175;
    [Range(0, 255)]
    public int Ch176;
    [Range(0, 255)]
    public int Ch177;
    [Range(0, 255)]
    public int Ch178;
    [Range(0, 255)]
    public int Ch179;
    [Range(0, 255)]
    public int Ch180;
    [Range(0, 255)]
    public int Ch181;
    [Range(0, 255)]
    public int Ch182;
    [Range(0, 255)]
    public int Ch183;
    [Range(0, 255)]
    public int Ch184;
    [Range(0, 255)]
    public int Ch185;
    [Range(0, 255)]
    public int Ch186;
    [Range(0, 255)]
    public int Ch187;
    [Range(0, 255)]
    public int Ch188;
    [Range(0, 255)]
    public int Ch189;
    [Range(0, 255)]
    public int Ch190;
    [Range(0, 255)]
    public int Ch191;
    [Range(0, 255)]
    public int Ch192;
    [Range(0, 255)]
    public int Ch193;
    [Range(0, 255)]
    public int Ch194;
    [Range(0, 255)]
    public int Ch195;
    [Range(0, 255)]
    public int Ch196;
    [Range(0, 255)]
    public int Ch197;
    [Range(0, 255)]
    public int Ch198;
    [Range(0, 255)]
    public int Ch199;
    [Range(0, 255)]
    public int Ch200;
    [Range(0, 255)]
    public int Ch201;
    [Range(0, 255)]
    public int Ch202;
    [Range(0, 255)]
    public int Ch203;
    [Range(0, 255)]
    public int Ch204;
    [Range(0, 255)]
    public int Ch205;
    [Range(0, 255)]
    public int Ch206;
    [Range(0, 255)]
    public int Ch207;
    [Range(0, 255)]
    public int Ch208;
    [Range(0, 255)]
    public int Ch209;
    [Range(0, 255)]
    public int Ch210;
    [Range(0, 255)]
    public int Ch211;
    [Range(0, 255)]
    public int Ch212;
    [Range(0, 255)]
    public int Ch213;
    [Range(0, 255)]
    public int Ch214;
    [Range(0, 255)]
    public int Ch215;
    [Range(0, 255)]
    public int Ch216;
    [Range(0, 255)]
    public int Ch217;
    [Range(0, 255)]
    public int Ch218;
    [Range(0, 255)]
    public int Ch219;
    [Range(0, 255)]
    public int Ch220;
    [Range(0, 255)]
    public int Ch221;
    [Range(0, 255)]
    public int Ch222;
    [Range(0, 255)]
    public int Ch223;
    [Range(0, 255)]
    public int Ch224;
    [Range(0, 255)]
    public int Ch225;
    [Range(0, 255)]
    public int Ch226;
    [Range(0, 255)]
    public int Ch227;
    [Range(0, 255)]
    public int Ch228;
    [Range(0, 255)]
    public int Ch229;
    [Range(0, 255)]
    public int Ch230;
    [Range(0, 255)]
    public int Ch231;
    [Range(0, 255)]
    public int Ch232;
    [Range(0, 255)]
    public int Ch233;
    [Range(0, 255)]
    public int Ch234;
    [Range(0, 255)]
    public int Ch235;
    [Range(0, 255)]
    public int Ch236;
    [Range(0, 255)]
    public int Ch237;
    [Range(0, 255)]
    public int Ch238;
    [Range(0, 255)]
    public int Ch239;
    [Range(0, 255)]
    public int Ch240;
    [Range(0, 255)]
    public int Ch241;
    [Range(0, 255)]
    public int Ch242;
    [Range(0, 255)]
    public int Ch243;
    [Range(0, 255)]
    public int Ch244;
    [Range(0, 255)]
    public int Ch245;
    [Range(0, 255)]
    public int Ch246;
    [Range(0, 255)]
    public int Ch247;
    [Range(0, 255)]
    public int Ch248;
    [Range(0, 255)]
    public int Ch249;
    [Range(0, 255)]
    public int Ch250;
    [Range(0, 255)]
    public int Ch251;
    [Range(0, 255)]
    public int Ch252;
    [Range(0, 255)]
    public int Ch253;
    [Range(0, 255)]
    public int Ch254;
    [Range(0, 255)]
    public int Ch255;
    [Range(0, 255)]
    public int Ch256;
    [Range(0, 255)]
    public int Ch257;
    [Range(0, 255)]
    public int Ch258;
    [Range(0, 255)]
    public int Ch259;
    [Range(0, 255)]
    public int Ch260;
    [Range(0, 255)]
    public int Ch261;
    [Range(0, 255)]
    public int Ch262;
    [Range(0, 255)]
    public int Ch263;
    [Range(0, 255)]
    public int Ch264;
    [Range(0, 255)]
    public int Ch265;
    [Range(0, 255)]
    public int Ch266;
    [Range(0, 255)]
    public int Ch267;
    [Range(0, 255)]
    public int Ch268;
    [Range(0, 255)]
    public int Ch269;
    [Range(0, 255)]
    public int Ch270;
    [Range(0, 255)]
    public int Ch271;
    [Range(0, 255)]
    public int Ch272;
    [Range(0, 255)]
    public int Ch273;
    [Range(0, 255)]
    public int Ch274;
    [Range(0, 255)]
    public int Ch275;
    [Range(0, 255)]
    public int Ch276;
    [Range(0, 255)]
    public int Ch277;
    [Range(0, 255)]
    public int Ch278;
    [Range(0, 255)]
    public int Ch279;
    [Range(0, 255)]
    public int Ch280;
    [Range(0, 255)]
    public int Ch281;
    [Range(0, 255)]
    public int Ch282;
    [Range(0, 255)]
    public int Ch283;
    [Range(0, 255)]
    public int Ch284;
    [Range(0, 255)]
    public int Ch285;
    [Range(0, 255)]
    public int Ch286;
    [Range(0, 255)]
    public int Ch287;
    [Range(0, 255)]
    public int Ch288;
    [Range(0, 255)]
    public int Ch289;
    [Range(0, 255)]
    public int Ch290;
    [Range(0, 255)]
    public int Ch291;
    [Range(0, 255)]
    public int Ch292;
    [Range(0, 255)]
    public int Ch293;
    [Range(0, 255)]
    public int Ch294;
    [Range(0, 255)]
    public int Ch295;
    [Range(0, 255)]
    public int Ch296;
    [Range(0, 255)]
    public int Ch297;
    [Range(0, 255)]
    public int Ch298;
    [Range(0, 255)]
    public int Ch299;
    [Range(0, 255)]
    public int Ch300;
    [Range(0, 255)]
    public int Ch301;
    [Range(0, 255)]
    public int Ch302;
    [Range(0, 255)]
    public int Ch303;
    [Range(0, 255)]
    public int Ch304;
    [Range(0, 255)]
    public int Ch305;
    [Range(0, 255)]
    public int Ch306;
    [Range(0, 255)]
    public int Ch307;
    [Range(0, 255)]
    public int Ch308;
    [Range(0, 255)]
    public int Ch309;
    [Range(0, 255)]
    public int Ch310;
    [Range(0, 255)]
    public int Ch311;
    [Range(0, 255)]
    public int Ch312;
    [Range(0, 255)]
    public int Ch313;
    [Range(0, 255)]
    public int Ch314;
    [Range(0, 255)]
    public int Ch315;
    [Range(0, 255)]
    public int Ch316;
    [Range(0, 255)]
    public int Ch317;
    [Range(0, 255)]
    public int Ch318;
    [Range(0, 255)]
    public int Ch319;
    [Range(0, 255)]
    public int Ch320;
    [Range(0, 255)]
    public int Ch321;
    [Range(0, 255)]
    public int Ch322;
    [Range(0, 255)]
    public int Ch323;
    [Range(0, 255)]
    public int Ch324;
    [Range(0, 255)]
    public int Ch325;
    [Range(0, 255)]
    public int Ch326;
    [Range(0, 255)]
    public int Ch327;
    [Range(0, 255)]
    public int Ch328;
    [Range(0, 255)]
    public int Ch329;
    [Range(0, 255)]
    public int Ch330;
    [Range(0, 255)]
    public int Ch331;
    [Range(0, 255)]
    public int Ch332;
    [Range(0, 255)]
    public int Ch333;
    [Range(0, 255)]
    public int Ch334;
    [Range(0, 255)]
    public int Ch335;
    [Range(0, 255)]
    public int Ch336;
    [Range(0, 255)]
    public int Ch337;
    [Range(0, 255)]
    public int Ch338;
    [Range(0, 255)]
    public int Ch339;
    [Range(0, 255)]
    public int Ch340;
    [Range(0, 255)]
    public int Ch341;
    [Range(0, 255)]
    public int Ch342;
    [Range(0, 255)]
    public int Ch343;
    [Range(0, 255)]
    public int Ch344;
    [Range(0, 255)]
    public int Ch345;
    [Range(0, 255)]
    public int Ch346;
    [Range(0, 255)]
    public int Ch347;
    [Range(0, 255)]
    public int Ch348;
    [Range(0, 255)]
    public int Ch349;
    [Range(0, 255)]
    public int Ch350;
    [Range(0, 255)]
    public int Ch351;
    [Range(0, 255)]
    public int Ch352;
    [Range(0, 255)]
    public int Ch353;
    [Range(0, 255)]
    public int Ch354;
    [Range(0, 255)]
    public int Ch355;
    [Range(0, 255)]
    public int Ch356;
    [Range(0, 255)]
    public int Ch357;
    [Range(0, 255)]
    public int Ch358;
    [Range(0, 255)]
    public int Ch359;
    [Range(0, 255)]
    public int Ch360;
    [Range(0, 255)]
    public int Ch361;
    [Range(0, 255)]
    public int Ch362;
    [Range(0, 255)]
    public int Ch363;
    [Range(0, 255)]
    public int Ch364;
    [Range(0, 255)]
    public int Ch365;
    [Range(0, 255)]
    public int Ch366;
    [Range(0, 255)]
    public int Ch367;
    [Range(0, 255)]
    public int Ch368;
    [Range(0, 255)]
    public int Ch369;
    [Range(0, 255)]
    public int Ch370;
    [Range(0, 255)]
    public int Ch371;
    [Range(0, 255)]
    public int Ch372;
    [Range(0, 255)]
    public int Ch373;
    [Range(0, 255)]
    public int Ch374;
    [Range(0, 255)]
    public int Ch375;
    [Range(0, 255)]
    public int Ch376;
    [Range(0, 255)]
    public int Ch377;
    [Range(0, 255)]
    public int Ch378;
    [Range(0, 255)]
    public int Ch379;
    [Range(0, 255)]
    public int Ch380;
    [Range(0, 255)]
    public int Ch381;
    [Range(0, 255)]
    public int Ch382;
    [Range(0, 255)]
    public int Ch383;
    [Range(0, 255)]
    public int Ch384;
    [Range(0, 255)]
    public int Ch385;
    [Range(0, 255)]
    public int Ch386;
    [Range(0, 255)]
    public int Ch387;
    [Range(0, 255)]
    public int Ch388;
    [Range(0, 255)]
    public int Ch389;
    [Range(0, 255)]
    public int Ch390;
    [Range(0, 255)]
    public int Ch391;
    [Range(0, 255)]
    public int Ch392;
    [Range(0, 255)]
    public int Ch393;
    [Range(0, 255)]
    public int Ch394;
    [Range(0, 255)]
    public int Ch395;
    [Range(0, 255)]
    public int Ch396;
    [Range(0, 255)]
    public int Ch397;
    [Range(0, 255)]
    public int Ch398;
    [Range(0, 255)]
    public int Ch399;
    [Range(0, 255)]
    public int Ch400;
    [Range(0, 255)]
    public int Ch401;
    [Range(0, 255)]
    public int Ch402;
    [Range(0, 255)]
    public int Ch403;
    [Range(0, 255)]
    public int Ch404;
    [Range(0, 255)]
    public int Ch405;
    [Range(0, 255)]
    public int Ch406;
    [Range(0, 255)]
    public int Ch407;
    [Range(0, 255)]
    public int Ch408;
    [Range(0, 255)]
    public int Ch409;
    [Range(0, 255)]
    public int Ch410;
    [Range(0, 255)]
    public int Ch411;
    [Range(0, 255)]
    public int Ch412;
    [Range(0, 255)]
    public int Ch413;
    [Range(0, 255)]
    public int Ch414;
    [Range(0, 255)]
    public int Ch415;
    [Range(0, 255)]
    public int Ch416;
    [Range(0, 255)]
    public int Ch417;
    [Range(0, 255)]
    public int Ch418;
    [Range(0, 255)]
    public int Ch419;
    [Range(0, 255)]
    public int Ch420;
    [Range(0, 255)]
    public int Ch421;
    [Range(0, 255)]
    public int Ch422;
    [Range(0, 255)]
    public int Ch423;
    [Range(0, 255)]
    public int Ch424;
    [Range(0, 255)]
    public int Ch425;
    [Range(0, 255)]
    public int Ch426;
    [Range(0, 255)]
    public int Ch427;
    [Range(0, 255)]
    public int Ch428;
    [Range(0, 255)]
    public int Ch429;
    [Range(0, 255)]
    public int Ch430;
    [Range(0, 255)]
    public int Ch431;
    [Range(0, 255)]
    public int Ch432;
    [Range(0, 255)]
    public int Ch433;
    [Range(0, 255)]
    public int Ch434;
    [Range(0, 255)]
    public int Ch435;
    [Range(0, 255)]
    public int Ch436;
    [Range(0, 255)]
    public int Ch437;
    [Range(0, 255)]
    public int Ch438;
    [Range(0, 255)]
    public int Ch439;
    [Range(0, 255)]
    public int Ch440;
    [Range(0, 255)]
    public int Ch441;
    [Range(0, 255)]
    public int Ch442;
    [Range(0, 255)]
    public int Ch443;
    [Range(0, 255)]
    public int Ch444;
    [Range(0, 255)]
    public int Ch445;
    [Range(0, 255)]
    public int Ch446;
    [Range(0, 255)]
    public int Ch447;
    [Range(0, 255)]
    public int Ch448;
    [Range(0, 255)]
    public int Ch449;
    [Range(0, 255)]
    public int Ch450;
    [Range(0, 255)]
    public int Ch451;
    [Range(0, 255)]
    public int Ch452;
    [Range(0, 255)]
    public int Ch453;
    [Range(0, 255)]
    public int Ch454;
    [Range(0, 255)]
    public int Ch455;
    [Range(0, 255)]
    public int Ch456;
    [Range(0, 255)]
    public int Ch457;
    [Range(0, 255)]
    public int Ch458;
    [Range(0, 255)]
    public int Ch459;
    [Range(0, 255)]
    public int Ch460;
    [Range(0, 255)]
    public int Ch461;
    [Range(0, 255)]
    public int Ch462;
    [Range(0, 255)]
    public int Ch463;
    [Range(0, 255)]
    public int Ch464;
    [Range(0, 255)]
    public int Ch465;
    [Range(0, 255)]
    public int Ch466;
    [Range(0, 255)]
    public int Ch467;
    [Range(0, 255)]
    public int Ch468;
    [Range(0, 255)]
    public int Ch469;
    [Range(0, 255)]
    public int Ch470;
    [Range(0, 255)]
    public int Ch471;
    [Range(0, 255)]
    public int Ch472;
    [Range(0, 255)]
    public int Ch473;
    [Range(0, 255)]
    public int Ch474;
    [Range(0, 255)]
    public int Ch475;
    [Range(0, 255)]
    public int Ch476;
    [Range(0, 255)]
    public int Ch477;
    [Range(0, 255)]
    public int Ch478;
    [Range(0, 255)]
    public int Ch479;
    [Range(0, 255)]
    public int Ch480;
    [Range(0, 255)]
    public int Ch481;
    [Range(0, 255)]
    public int Ch482;
    [Range(0, 255)]
    public int Ch483;
    [Range(0, 255)]
    public int Ch484;
    [Range(0, 255)]
    public int Ch485;
    [Range(0, 255)]
    public int Ch486;
    [Range(0, 255)]
    public int Ch487;
    [Range(0, 255)]
    public int Ch488;
    [Range(0, 255)]
    public int Ch489;
    [Range(0, 255)]
    public int Ch490;
    [Range(0, 255)]
    public int Ch491;
    [Range(0, 255)]
    public int Ch492;
    [Range(0, 255)]
    public int Ch493;
    [Range(0, 255)]
    public int Ch494;
    [Range(0, 255)]
    public int Ch495;
    [Range(0, 255)]
    public int Ch496;
    [Range(0, 255)]
    public int Ch497;
    [Range(0, 255)]
    public int Ch498;
    [Range(0, 255)]
    public int Ch499;
    [Range(0, 255)]
    public int Ch500;
    [Range(0, 255)]
    public int Ch501;
    [Range(0, 255)]
    public int Ch502;
    [Range(0, 255)]
    public int Ch503;
    [Range(0, 255)]
    public int Ch504;
    [Range(0, 255)]
    public int Ch505;
    [Range(0, 255)]
    public int Ch506;
    [Range(0, 255)]
    public int Ch507;
    [Range(0, 255)]
    public int Ch508;
    [Range(0, 255)]
    public int Ch509;
    [Range(0, 255)]
    public int Ch510;
    [Range(0, 255)]
    public int Ch511;
    [Range(0, 255)]
    public int Ch512;
    #endregion
    #region refrection
    public int this[int index]
    {
        get
        {
            if (index < 1 || index > 512)
            {
                throw new ArgumentOutOfRangeException("index", "Channel index out of range");
            }

            var field = GetType().GetField("Ch" + index);
            if (field == null)
            {
                throw new Exception("Field Ch" + index + " not found");
            }

            int value = (int)field.GetValue(this);

            // 値を0から255の範囲に制限します
            value = Mathf.Clamp(value, 0, 255);

            return value;
        }
        set
        {
            if (index < 1 || index > 512)
            {
                throw new ArgumentOutOfRangeException("index", "Channel index out of range");
            }

            var field = GetType().GetField("Ch" + index);
            if (field == null)
            {
                throw new Exception("Field Ch" + index + " not found");
            }

            // 値を0から255の範囲に制限します
            value = Mathf.Clamp(value, 0, 255);

            field.SetValue(this, value);
        }
    }
    #endregion

}